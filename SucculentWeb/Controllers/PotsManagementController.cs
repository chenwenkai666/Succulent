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
    public class PotsManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();

        // GET: PotsManagement
        public ActionResult Index()
        {
            var pots = db.Pots.Include(p => p.Level).Include(p => p.Users);
            return View(pots.ToList());
        }

        // GET: PotsManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pots pots = db.Pots.Find(id);
            if (pots == null)
            {
                return HttpNotFound();
            }
            return View(pots);
        }

        // GET: PotsManagement/Create
        public ActionResult Create()
        {
            ViewBag.LevelID = new SelectList(db.Level, "LevelID", "LevelName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: PotsManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PotID,UserID,LevelID,Experience,Sign,SignDays")] Pots pots)
        {
            if (ModelState.IsValid)
            {
                db.Pots.Add(pots);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LevelID = new SelectList(db.Level, "LevelID", "LevelName", pots.LevelID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", pots.UserID);
            return View(pots);
        }

        // GET: PotsManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pots pots = db.Pots.Find(id);
            if (pots == null)
            {
                return HttpNotFound();
            }
            ViewBag.LevelID = new SelectList(db.Level, "LevelID", "LevelName", pots.LevelID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", pots.UserID);
            return View(pots);
        }

        // POST: PotsManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PotID,UserID,LevelID,Experience,Sign,SignDays")] Pots pots)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pots).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LevelID = new SelectList(db.Level, "LevelID", "LevelName", pots.LevelID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", pots.UserID);
            return View(pots);
        }

        // GET: PotsManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pots pots = db.Pots.Find(id);
            if (pots == null)
            {
                return HttpNotFound();
            }
            return View(pots);
        }

        // POST: PotsManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pots pots = db.Pots.Find(id);
            db.Pots.Remove(pots);
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
