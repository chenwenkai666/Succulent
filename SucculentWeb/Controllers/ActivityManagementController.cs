﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace SucculentWeb.Controllers
{
    public class ActivityManagementController : Controller
    {
        private SucculentEntities db = new SucculentEntities();
        PotsManager potmanager = new PotsManager();

        // GET: ActivityManagement
        public ActionResult Index()
        {
            var activity = db.Activity.Include(a => a.ActivityCategory).Include(a => a.Users);
            return View(activity.ToList());
        }

        // GET: ActivityManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: ActivityManagement/Create
        public ActionResult Create()
        {
            ViewBag.ActivityCategoryID = new SelectList(db.ActivityCategory, "ActivityCategoryID", "ActivityCategoryName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ActivityManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityID,UserID,ActivityCategoryID,ActivityName,ActivityDescribe,ActivityPlace,StartTime,EndTime,UpvoteNum,ActivityCover,AttendConditions,LevelRequest")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activity.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityCategoryID = new SelectList(db.ActivityCategory, "ActivityCategoryID", "ActivityCategoryName", activity.ActivityCategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", activity.UserID);
            return View(activity);
        }

        // GET: ActivityManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityCategoryID = new SelectList(db.ActivityCategory, "ActivityCategoryID", "ActivityCategoryName", activity.ActivityCategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", activity.UserID);
            return View(activity);
        }

        // POST: ActivityManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityID,UserID,ActivityCategoryID,ActivityName,ActivityDescribe,ActivityPlace,StartTime,EndTime,UpvoteNum,ActivityCover,AttendConditions,LevelRequest")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityCategoryID = new SelectList(db.ActivityCategory, "ActivityCategoryID", "ActivityCategoryName", activity.ActivityCategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", activity.UserID);
            return View(activity);
        }

        // GET: ActivityManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: ActivityManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activity.Find(id);
            db.Activity.Remove(activity);
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

        public ActionResult CheckOut(int id)
        {
            var UserList = db.Entries.Where(e => e.ActivityID == id).ToList();
            if(UserList!=null && UserList.Count > 0)
            {
                try
                {
                    for (int i = 0; i < UserList.Count; i++)
                    {
                        potmanager.UpdateExperience(UserList[i].UserID, int.Parse(UserList[i].UpvoteNum.ToString()));
                    }
                    return Content("<script>alert('结算成功，积分已发放至用户账号！');window.location='" + Url.Action("Index", "ActivityManagement") + "'</script>");
                }
                catch (Exception ex)
                {
                    return Content("<script>alert('结算出错，错误原因：'"+ex+");window.location='" + Url.Action("Index", "ActivityManagement") + "'</script>");
                    throw;
                }
                
            }
            return Content("<script>alert('该活动无人参与，无法对其进行结算！');window.location='" + Url.Action("Index", "ActivityManagement") + "'</script>");
        }

    }
}
