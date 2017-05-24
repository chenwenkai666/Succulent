using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SucculentWeb.ViewModels;
using Model;
using PagedList;

namespace SucculentWeb.Controllers
{
    public class SucculentIndexController : Controller
    {
        SucculentEntities db = new SucculentEntities();
        public ActionResult Succulent()
        {
            var category = db.SucculentCategory.ToList();
            return View(category);
        }             
        public ActionResult PartialViewDate(int? page,int SucculentCategoryID=1)
        {
            int pageSize = 9;
            int pageNum = (page ?? 1);   
            var succulent = db.Succulent.Where(s => s.CategoryID == SucculentCategoryID);
            var category = db.SucculentCategory.Where(c => c.SucculentCategoryID == SucculentCategoryID).FirstOrDefault();
            ViewBag.name = category.SucculentCategoryName;
            ViewBag.details = category.SucculentCategoryDescribe;
            ViewBag.id = category.SucculentCategoryID;
            if (Request.IsAjaxRequest())
            {
              return PartialView("PartialViewDate", succulent.OrderBy(s => s.CollectedTotal).ToPagedList(pageNum, pageSize));
            }          
            else
            {
                return View("PartialViewDate", succulent.OrderBy(s => s.CollectedTotal).ToPagedList(pageNum, pageSize));
            }
        }

        }
}