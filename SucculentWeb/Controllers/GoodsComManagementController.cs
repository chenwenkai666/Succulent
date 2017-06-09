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
    public class GoodsComManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: GoodsComManagement
        public ActionResult Index()
        {
            var goodsComments = db.GoodsComments.Include(g => g.Goods).Include(g => g.Users);
            return View(goodsComments.ToList());
        }

        // GET: GoodsComManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsComments goodsComments = db.GoodsComments.Find(id);
            if (goodsComments == null)
            {
                return HttpNotFound();
            }
            return View(goodsComments);
        }

        // GET: GoodsComManagement/Create
        public ActionResult Create()
        {
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "GoodsName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: GoodsComManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsCommentID,UserID,GoodsID,GoodsCommentContent,PublishTime")] GoodsComments goodsComments)
        {
            if (ModelState.IsValid)
            {
                db.GoodsComments.Add(goodsComments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "GoodsName", goodsComments.GoodsID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", goodsComments.UserID);
            return View(goodsComments);
        }

        // GET: GoodsComManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsComments goodsComments = db.GoodsComments.Find(id);
            if (goodsComments == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "GoodsName", goodsComments.GoodsID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", goodsComments.UserID);
            return View(goodsComments);
        }

        // POST: GoodsComManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsCommentID,UserID,GoodsID,GoodsCommentContent,PublishTime")] GoodsComments goodsComments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goodsComments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "GoodsName", goodsComments.GoodsID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", goodsComments.UserID);
            return View(goodsComments);
        }

        // GET: GoodsComManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsComments goodsComments = db.GoodsComments.Find(id);
            if (goodsComments == null)
            {
                return HttpNotFound();
            }
            return View(goodsComments);
        }

        // POST: GoodsComManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoodsComments goodsComments = db.GoodsComments.Find(id);
            db.GoodsComments.Remove(goodsComments);
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
