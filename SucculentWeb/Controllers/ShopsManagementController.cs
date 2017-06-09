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
    public class ShopsManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: ShopsManagement
        public ActionResult Index()
        {
            var shops = db.Shops.Include(s => s.Users);
            return View(shops.ToList());
        }

        // GET: ShopsManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shops shops = db.Shops.Find(id);
            if (shops == null)
            {
                return HttpNotFound();
            }
            return View(shops);
        }

        // GET: ShopsManagement/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ShopsManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopID,UserID,ShopName,ShopDescription,SalesTotal,ShopPhoto,TopImage")] Shops shops)
        {
            if (ModelState.IsValid)
            {
                db.Shops.Add(shops);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", shops.UserID);
            return View(shops);
        }

        // GET: ShopsManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shops shops = db.Shops.Find(id);
            if (shops == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", shops.UserID);
            return View(shops);
        }

        // POST: ShopsManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopID,UserID,ShopName,ShopDescription,SalesTotal,ShopPhoto,TopImage")] Shops shops)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shops).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", shops.UserID);
            return View(shops);
        }

        // GET: ShopsManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shops shops = db.Shops.Find(id);
            if (shops == null)
            {
                return HttpNotFound();
            }
            return View(shops);
        }

        // POST: ShopsManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shops shops = db.Shops.Find(id);
            db.Shops.Remove(shops);
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
