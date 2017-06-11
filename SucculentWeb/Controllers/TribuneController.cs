using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using SucculentWeb.ViewModels.TribuneVM;
using Model;
using PagedList;
using SucculentWeb.Attributes;

namespace SucculentWeb.Controllers
{
    public class TribuneController : Controller
    {
        SucculentEntities db = new SucculentEntities();
        PostsManager PostM = new PostsManager();
        PotsManager potsmanager = new PotsManager();
        // GET: Tribune
        public ActionResult TribuneIndex()
        {
            TribuneIndexVM indexvm = new TribuneIndexVM();
            indexvm.SelectIndexPost01 = PostM.SelectIndexPost01();
            indexvm.SelectIndexPost02 = PostM.SelectIndexPost02();
            indexvm.SelectIndexPost03 = PostM.SelectIndexPost03();
            indexvm.Sections03 = PostM.GetSection03();
            indexvm.Sections06 = PostM.GetSection06();
            indexvm.GetAllPostNum = PostM.GetAllPostNum();
            indexvm.GetTodayPostNum = PostM.GetTodayPostNum();
            indexvm.GetYesterdayPostNum = PostM.GetYesterdayPostNum();
            return View(indexvm);
        }
        public ActionResult BoardIndex(int BoardID)
        {
            Session["BoardID"] = BoardID;
            TribuneBoardVM tribuneBoard = new TribuneBoardVM();
            tribuneBoard.Posts = PostM.GetSectionPost(BoardID);
            tribuneBoard.Sections = PostM.GetSectionName(BoardID);
            tribuneBoard.PostsNumberAll = PostM.GetPostNumberAll(BoardID);
            tribuneBoard.PostsNumberToday = PostM.GetPostNumberToday(BoardID);
            if (Session["UserID"] != null)
            {
                int userid = Convert.ToInt32(Session["UserID"]);
                tribuneBoard.Boardlevels = PostM.SelectUserLevel(userid);
            }
            return View(tribuneBoard);
        }

        [IsLogIn(IsCheck = true)]
        public ActionResult CreatePost()
        {
            TribuneCreateVM tribuneCreate = new TribuneCreateVM();
            tribuneCreate.Sections03 = PostM.GetSection03();
            tribuneCreate.Sections06 = PostM.GetSection06();
            tribuneCreate.Sections33 = PostM.GetSection33();
            return View(tribuneCreate);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePost(Posts posts, PostComments postscom)
        {
            int BoardID = Convert.ToInt32(Session["BoardID"]);
            int userid = Convert.ToInt32(Session["UserID"]);
            string timer = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime PubTime = DateTime.Parse(timer);
            string SectionName = Request.Form["selectdetailtype"];


            if (posts.PostContent == null)
            {
                return Content("<script>alert('帖子内容不能为空');window.open('" + Url.Action("CreatePost", "Tribune") + "', '_self'</script>");
            }
            else
            {
                int SectionID = PostM.SelectSectionID(SectionName);
                posts.SectionID = SectionID;
                posts.UserID = userid;
                posts.PublishTime = PubTime;
                posts.PostFlag = 1;
                db.Posts.Add(posts);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                int Lev = PostM.GetUserPotLev(Convert.ToInt32(Session["UserID"]));
                if (Lev != 0)
                {
                    potsmanager.UpdateExperience(userid, 5);
                }
                return RedirectToAction("BoardIndex", "Tribune", new { BoardID = BoardID });
            }
            
        }
        public ActionResult PostsDetails(int PostID, int? page)
        {
            const int pagesize = 10;
            int pageNum = (page ?? 1);
            Session["PostID"] = PostID;
            TribunePostVM tribunePost = new TribunePostVM();
            tribunePost.Posts = PostM.GetPostDetails(PostID);
            tribunePost.PostComment = PostM.GetPostComments(PostID).ToPagedList(pageNum, pagesize);
            if (Session["UserName"] != null)
            {
                string UserName = Session["UserName"].ToString();
                tribunePost.UserInfo = PostM.SelectUserInfo(UserName);
            }
            return View(tribunePost);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PostsDetails(PostComments postcom)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            int PostID = int.Parse(Session["PostID"].ToString());
           
            postcom.PostCommentContent = Request.Form["PostCommentContent"];
            if (postcom.PostCommentContent == "")
            {
                return Content("<script>alert('评论内容不能为空');window.open('" + Url.Action("PostsDetails", "Tribune", new { PostID = PostID }) + "', '_self'</script>");
            }
            else
            {
                postcom.UserID = Convert.ToInt32(Session["UserID"]);
                postcom.PostID = PostID;
                postcom.PostCommentTime = DateTime.Now;
                db.PostComments.Add(postcom);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                int Lev = PostM.GetUserPotLev(Convert.ToInt32(Session["UserID"]));
                if (Lev != 0)
                {
                    potsmanager.UpdateExperience(userid, 2);
                }
                return RedirectToAction("PostsDetails", "Tribune", new { PostID = PostID });
            }
            
            
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RlyPosts(ReplyPost rlypost, int PostCommentID)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            int PostID = int.Parse(Session["PostID"].ToString());
            rlypost.UserID = Convert.ToInt32(Session["UserID"]);
            rlypost.PostCommentID = PostCommentID;
            rlypost.ReplyPostTime = DateTime.Now;
            rlypost.ReplyContent = Request.Form["RlyPosts.ReplyContent"];
            db.ReplyPost.Add(rlypost);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            int Lev = PostM.GetUserPotLev(Convert.ToInt32(Session["UserID"]));
            if (Lev != 0)
            {
                potsmanager.UpdateExperience(userid, 2);
            }
            return RedirectToAction("PostsDetails", "Tribune", new { PostID = PostID });
        }
        public ActionResult PostsList(int? page, int BoardID)
        {
            const int pageSize = 20;
            int pagenumber = (page ?? 1);
            var postslist = PostM.GetSectionPost(BoardID).ToPagedList(pagenumber, pageSize);
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
            searchVM.infouser = PostM.SelectInfoUsers(searchinfo);
            searchVM.infopost = PostM.SelectInfoPosts(searchinfo);
            searchVM.infopostcom = PostM.SelectInfoPostCom(searchinfo);
            searchVM.infopostrly = PostM.SelectInfoReplyPost(searchinfo);
            return View(searchVM);
        }
    }
}