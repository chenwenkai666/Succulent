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
    public class DonateManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: DonateManagement
        public ActionResult Index()
        {
            var donate = db.Donate.Include(d => d.Users).Include(d => d.Activity);
            return View(donate.ToList());
        }

        // GET: DonateManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donate donate = db.Donate.Find(id);
            if (donate == null)
            {
                return HttpNotFound();
            }
            return View(donate);
        }

        // GET: DonateManagement/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            ViewBag.ActivityID = new SelectList(db.Activity, "ActivityID", "ActivityName");
            return View();
        }

        // POST: DonateManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonateID,UserID,DonateTime,DonoteTotal,DonateContent,ExoressNumber,DonateState,ActivityID")] Donate donate)
        {
            if (ModelState.IsValid)
            {
                db.Donate.Add(donate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", donate.UserID);
            ViewBag.ActivityID = new SelectList(db.Activity, "ActivityID", "ActivityName", donate.ActivityID);
            return View(donate);
        }

        // GET: DonateManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donate donate = db.Donate.Find(id);
            if (donate == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", donate.UserID);
            ViewBag.ActivityID = new SelectList(db.Activity, "ActivityID", "ActivityName", donate.ActivityID);
            return View(donate);
        }

        // POST: DonateManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonateID,UserID,DonateTime,DonoteTotal,DonateContent,ExoressNumber,DonateState,ActivityID")] Donate donate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", donate.UserID);
            ViewBag.ActivityID = new SelectList(db.Activity, "ActivityID", "ActivityName", donate.ActivityID);
            return View(donate);
        }

        // GET: DonateManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donate donate = db.Donate.Find(id);
            if (donate == null)
            {
                return HttpNotFound();
            }
            return View(donate);
        }

        // POST: DonateManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donate donate = db.Donate.Find(id);
            db.Donate.Remove(donate);
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
