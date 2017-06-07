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
    public class SucculentCateManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: SucculentCateManagement
        public ActionResult Index()
        {
            return View(db.SucculentCategory.ToList());
        }

        // GET: SucculentCateManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucculentCategory succulentCategory = db.SucculentCategory.Find(id);
            if (succulentCategory == null)
            {
                return HttpNotFound();
            }
            return View(succulentCategory);
        }

        // GET: SucculentCateManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SucculentCateManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SucculentCategoryID,SucculentCategoryName,SucculentCategoryDescribe")] SucculentCategory succulentCategory)
        {
            if (ModelState.IsValid)
            {
                db.SucculentCategory.Add(succulentCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(succulentCategory);
        }

        // GET: SucculentCateManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucculentCategory succulentCategory = db.SucculentCategory.Find(id);
            if (succulentCategory == null)
            {
                return HttpNotFound();
            }
            return View(succulentCategory);
        }

        // POST: SucculentCateManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SucculentCategoryID,SucculentCategoryName,SucculentCategoryDescribe")] SucculentCategory succulentCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(succulentCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(succulentCategory);
        }

        // GET: SucculentCateManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucculentCategory succulentCategory = db.SucculentCategory.Find(id);
            if (succulentCategory == null)
            {
                return HttpNotFound();
            }
            return View(succulentCategory);
        }

        // POST: SucculentCateManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucculentCategory succulentCategory = db.SucculentCategory.Find(id);
            db.SucculentCategory.Remove(succulentCategory);
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
