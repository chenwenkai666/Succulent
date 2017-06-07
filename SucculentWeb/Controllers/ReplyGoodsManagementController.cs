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
    public class ReplyGoodsManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: ReplyGoodsManagement
        public ActionResult Index()
        {
            var replyGoods = db.ReplyGoods.Include(r => r.GoodsComments).Include(r => r.Users);
            return View(replyGoods.ToList());
        }

        // GET: ReplyGoodsManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyGoods replyGoods = db.ReplyGoods.Find(id);
            if (replyGoods == null)
            {
                return HttpNotFound();
            }
            return View(replyGoods);
        }

        // GET: ReplyGoodsManagement/Create
        public ActionResult Create()
        {
            ViewBag.GoodsCommentID = new SelectList(db.GoodsComments, "GoodsCommentID", "GoodsCommentContent");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ReplyGoodsManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReplyGoodsID,UserID,GoodsCommentID,ReplyContent,ReplyTime")] ReplyGoods replyGoods)
        {
            if (ModelState.IsValid)
            {
                db.ReplyGoods.Add(replyGoods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoodsCommentID = new SelectList(db.GoodsComments, "GoodsCommentID", "GoodsCommentContent", replyGoods.GoodsCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", replyGoods.UserID);
            return View(replyGoods);
        }

        // GET: ReplyGoodsManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyGoods replyGoods = db.ReplyGoods.Find(id);
            if (replyGoods == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoodsCommentID = new SelectList(db.GoodsComments, "GoodsCommentID", "GoodsCommentContent", replyGoods.GoodsCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", replyGoods.UserID);
            return View(replyGoods);
        }

        // POST: ReplyGoodsManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReplyGoodsID,UserID,GoodsCommentID,ReplyContent,ReplyTime")] ReplyGoods replyGoods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replyGoods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoodsCommentID = new SelectList(db.GoodsComments, "GoodsCommentID", "GoodsCommentContent", replyGoods.GoodsCommentID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", replyGoods.UserID);
            return View(replyGoods);
        }

        // GET: ReplyGoodsManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyGoods replyGoods = db.ReplyGoods.Find(id);
            if (replyGoods == null)
            {
                return HttpNotFound();
            }
            return View(replyGoods);
        }

        // POST: ReplyGoodsManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReplyGoods replyGoods = db.ReplyGoods.Find(id);
            db.ReplyGoods.Remove(replyGoods);
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
