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
    public class PostComManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: PostComManagement
        public ActionResult Index()
        {
            var postComments = db.PostComments.Include(p => p.Posts).Include(p => p.Users);
            return View(postComments.ToList());
        }

        // GET: PostComManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComments postComments = db.PostComments.Find(id);
            if (postComments == null)
            {
                return HttpNotFound();
            }
            return View(postComments);
        }

        // GET: PostComManagement/Create
        public ActionResult Create()
        {
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "PostTitle");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: PostComManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostCommentID,UserID,PostID,PostCommentContent,PostCommentTime")] PostComments postComments)
        {
            if (ModelState.IsValid)
            {
                db.PostComments.Add(postComments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostID = new SelectList(db.Posts, "PostID", "PostTitle", postComments.PostID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", postComments.UserID);
            return View(postComments);
        }

        // GET: PostComManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComments postComments = db.PostComments.Find(id);
            if (postComments == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "PostTitle", postComments.PostID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", postComments.UserID);
            return View(postComments);
        }

        // POST: PostComManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostCommentID,UserID,PostID,PostCommentContent,PostCommentTime")] PostComments postComments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postComments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "PostTitle", postComments.PostID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", postComments.UserID);
            return View(postComments);
        }

        // GET: PostComManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComments postComments = db.PostComments.Find(id);
            if (postComments == null)
            {
                return HttpNotFound();
            }
            return View(postComments);
        }

        // POST: PostComManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostComments postComments = db.PostComments.Find(id);
            db.PostComments.Remove(postComments);
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
