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
    public class PostsManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: PostsManagement
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Sections).Include(p => p.Users);
            return View(posts.ToList());
        }

        // GET: PostsManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // GET: PostsManagement/Create
        public ActionResult Create()
        {
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: PostsManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,UserID,SectionID,PostTitle,PostContent,PublishTime,PostFlag")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", posts.SectionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", posts.UserID);
            return View(posts);
        }

        // GET: PostsManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", posts.SectionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", posts.UserID);
            return View(posts);
        }

        // POST: PostsManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,UserID,SectionID,PostTitle,PostContent,PublishTime,PostFlag")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", posts.SectionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", posts.UserID);
            return View(posts);
        }

        // GET: PostsManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // POST: PostsManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posts posts = db.Posts.Find(id);
            db.Posts.Remove(posts);
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
