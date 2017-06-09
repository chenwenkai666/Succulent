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
    public class SucculentManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: SucculentManagement
        public ActionResult Index()
        {
            var succulent = db.Succulent.Include(s => s.SucculentCategory);
            return View(succulent.ToList());
        }

        // GET: SucculentManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Succulent succulent = db.Succulent.Find(id);
            if (succulent == null)
            {
                return HttpNotFound();
            }
            return View(succulent);
        }

        // GET: SucculentManagement/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.SucculentCategory, "SucculentCategoryID", "SucculentCategoryName");
            return View();
        }

        // POST: SucculentManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SucculentID,SucculentName,CategoryID,Photo,Feature,Application,BreedMode,CollectedTotal,SucculentImg")] Succulent succulent)
        {
            if (ModelState.IsValid)
            {
                db.Succulent.Add(succulent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.SucculentCategory, "SucculentCategoryID", "SucculentCategoryName", succulent.CategoryID);
            return View(succulent);
        }

        // GET: SucculentManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Succulent succulent = db.Succulent.Find(id);
            if (succulent == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.SucculentCategory, "SucculentCategoryID", "SucculentCategoryName", succulent.CategoryID);
            return View(succulent);
        }

        // POST: SucculentManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SucculentID,SucculentName,CategoryID,Photo,Feature,Application,BreedMode,CollectedTotal,SucculentImg")] Succulent succulent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(succulent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.SucculentCategory, "SucculentCategoryID", "SucculentCategoryName", succulent.CategoryID);
            return View(succulent);
        }

        // GET: SucculentManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Succulent succulent = db.Succulent.Find(id);
            if (succulent == null)
            {
                return HttpNotFound();
            }
            return View(succulent);
        }

        // POST: SucculentManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Succulent succulent = db.Succulent.Find(id);
            db.Succulent.Remove(succulent);
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
