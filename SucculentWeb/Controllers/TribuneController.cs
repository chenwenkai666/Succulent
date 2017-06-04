using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using SucculentWeb.ViewModels.TribuneVM;
using Model;
using PagedList;

namespace SucculentWeb.Controllers
{
    public class TribuneController : Controller
    {
        SucculentEntities db = new SucculentEntities();
        // GET: Tribune
        public ActionResult TribuneIndex()
        {
            TribuneIndexVM indexvm = new TribuneIndexVM();
            indexvm.Sections03 = PostsManager.GetSection03();
            indexvm.Sections06 = PostsManager.GetSection06();
            indexvm.GetAllPostNum = PostsManager.GetAllPostNum();
            indexvm.GetTodayPostNum = PostsManager.GetTodayPostNum();
            indexvm.GetYesterdayPostNum = PostsManager.GetYesterdayPostNum();
            return View(indexvm);
        }
        public ActionResult BoardIndex(int BoardID)
        {
            Session["BoardID"] = BoardID;
            TribuneBoardVM tribuneBoard = new TribuneBoardVM();
            tribuneBoard.Posts = PostsManager.GetSectionPost(BoardID);
            tribuneBoard.Sections = PostsManager.GetSectionName(BoardID);
            tribuneBoard.PostsNumberAll = PostsManager.GetPostNumberAll(BoardID);
            tribuneBoard.PostsNumberToday = PostsManager.GetPostNumberToday(BoardID);
            return View(tribuneBoard);
        }
        public ActionResult CreatePost()
        {
            TribuneCreateVM tribuneCreate = new TribuneCreateVM();
            tribuneCreate.Sections03 = PostsManager.GetSection03();
            tribuneCreate.Sections06 = PostsManager.GetSection06();
            return View(tribuneCreate);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePost(Posts posts, PostComments postscom)
        {
            int BoardID = Convert.ToInt32(Session["BoardID"]);
            try
            {
                int userid = Convert.ToInt32(Session["UserID"]);
                string timer = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime PubTime = DateTime.Parse(timer);
                string SectionName = Request.Form["selectdetailtype"];
                int SectionID = PostsManager.SelectSectionID(SectionName);
                posts.SectionID = SectionID;
                posts.UserID = userid;
                posts.PublishTime = PubTime;
                db.Posts.Add(posts);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;

                //var DATER = PostsManager.SelectPostFirstFloor(userid, PubTime);
                //postscom.UserID = userid;
                //postscom.PostID = DATER.PostID;
                //postscom.PostCommentContent = DATER.PostContent;
                //postscom.PostCommentTime = PubTime;
                //db.PostComments.Add(postscom);
                //db.Configuration.ValidateOnSaveEnabled = false;
                //db.SaveChanges();
                //db.Configuration.ValidateOnSaveEnabled = true;

                return RedirectToAction("BoardIndex", "Tribune", new { BoardID = BoardID });

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                return Content("<script>alert('输入有误！');window.location.href = document.referrer;</script>");
            }
        }
        public ActionResult PostsDetails(int PostID)
        {
            Session["PostID"] = PostID;
            TribunePostVM tribunePost = new TribunePostVM();
            tribunePost.Posts = PostsManager.GetPostDetails(PostID);
            tribunePost.PostComment = PostsManager.GetPostComments(PostID);
            if (Session["UserName"] != null)
            {
                string UserName = Session["UserName"].ToString();
                tribunePost.UserInfo = PostsManager.SelectUserInfo(UserName);
            }
            return View(tribunePost);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PostsDetails(PostComments postcom)
        {
            int PostID = int.Parse(Session["PostID"].ToString());
            postcom.UserID = Convert.ToInt32(Session["UserID"]);
            postcom.PostID = PostID;
            postcom.PostCommentTime = DateTime.Now;
            postcom.PostCommentContent = Request.Form["PostCommentContent"];
            db.PostComments.Add(postcom);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return RedirectToAction("PostsDetails", "Tribune", new { PostID = PostID });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RlyPosts(ReplyPost rlypost, int PostCommentID)
        {
            int PostID = int.Parse(Session["PostID"].ToString());
            rlypost.UserID = Convert.ToInt32(Session["UserID"]);
            rlypost.PostCommentID = PostCommentID;
            rlypost.ReplyPostTime = DateTime.Now;
            rlypost.ReplyContent = Request.Form["textarea1"];
            db.ReplyPost.Add(rlypost);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            return RedirectToAction("PostsDetails", "Tribune", new { PostID = PostID });
        }
        public ActionResult PostsList(int? page, int BoardID)
        {
            const int pageSize = 20;
            int pagenumber = (page ?? 1);
            var postslist = PostsManager.GetSectionPost(BoardID).ToPagedList(pagenumber, pageSize);
            return View(postslist);
        }
        public ActionResult UserQuit()
        {
            Session["UserName"] = null;
            Session["UserID"] = null;
            return Content("<script>window.location.href = document.referrer;</script>");
        }
        [HttpPost]
        public ActionResult SearchPost()
        {
            Session["searchinfo"] = null;
            TribuneSearchVM searchVM = new TribuneSearchVM();
            string searchinfo = Request.Form["searchinfo"];
            Session["searchinfo"] = searchinfo;
            searchVM.infouser = PostsManager.SelectInfoUsers(searchinfo);
            searchVM.infopost = PostsManager.SelectInfoPosts(searchinfo);
            searchVM.infopostcom = PostsManager.SelectInfoPostCom(searchinfo);
            searchVM.infopostrly = PostsManager.SelectInfoReplyPost(searchinfo);
            return View(searchVM);
        }
    }
}