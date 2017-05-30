using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using SucculentWeb.ViewModels;
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
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatePost(Posts posts, PostComments postscom)
        {
            int BoardID = Convert.ToInt32(Session["BoardID"]);
            try
            {
                if (posts.PostTitle.Length <= 24)
                {
                    if (posts.PostContent.ToString() != null)
                    {
                        int userid = Convert.ToInt32(Session["UserID"]);
                        string timer = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DateTime PubTime = DateTime.Parse(timer);
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
                    else
                    {
                        return RedirectToAction("CreatePost", "Tribune");
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                throw dbEx;
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
            const int pageSize = 10;
            int pagenumber = (page ?? 1);
            var postslist = PostsManager.GetSectionPost(BoardID).ToPagedList(pagenumber, pageSize);
            return View(postslist);
        }
    }
}