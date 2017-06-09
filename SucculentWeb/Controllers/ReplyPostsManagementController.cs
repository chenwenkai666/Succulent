using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;

namespace SucculentWeb.Controllers
{
    public class ReplyPostsManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: ReplyPostsManagement
        public ActionResult Index()
        {
            var replyPost = db.ReplyPost.Include(r => r.PostComments).Include(r => r.Users);
            return View(replyPost.ToList());
        }

        // GET: ReplyPostsManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyPost replyPost = db.ReplyPost.Find(id);
            if (replyPost == null)
            {
                return HttpNotFound();
            }
            return View(replyPost);
        }

        // GET: ReplyPostsManagement/Create
        public ActionResult Create()
        {
            ViewBag.PostCommentID = new SelectList(db.PostComments, "PostCommentID", "PostCommentContent");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ReplyPostsManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReplyPostID,UserID,PostCommentID,ReplyContent,ReplyPostTime")] ReplyPost replyPost)
        {
            if (ModelState.IsValid)
            {
                db.ReplyPost.Add(replyPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostCommentID = new SelectList(db.PostComments, "PostCommentID", "PostCommentContent", replyPost.PostCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", replyPost.UserID);
            return View(replyPost);
        }

        // GET: ReplyPostsManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyPost replyPost = db.ReplyPost.Find(id);
            if (replyPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostCommentID = new SelectList(db.PostComments, "PostCommentID", "PostCommentContent", replyPost.PostCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", replyPost.UserID);
            return View(replyPost);
        }

        // POST: ReplyPostsManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReplyPostID,UserID,PostCommentID,ReplyContent,ReplyPostTime")] ReplyPost replyPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replyPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostCommentID = new SelectList(db.PostComments, "PostCommentID", "PostCommentContent", replyPost.PostCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", replyPost.UserID);
            return View(replyPost);
        }

        // GET: ReplyPostsManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyPost replyPost = db.ReplyPost.Find(id);
            if (replyPost == null)
            {
                return HttpNotFound();
            }
            return View(replyPost);
        }

        // POST: ReplyPostsManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReplyPost replyPost = db.ReplyPost.Find(id);
            db.ReplyPost.Remove(replyPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
