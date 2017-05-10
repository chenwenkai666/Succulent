using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace SucculentWeb.Controllers
{
    public class SucculentController : Controller
    {
        public ActionResult Succulent()
        {
            return View();
        }
        // GET: Succulent
        //查找
        public ActionResult Succulent_Details()
        {
            //var succulent = SucculentManager.SelectSucculent();
            //return View(succulent);
            var succulent = SucculentManager.SelectSucculentByID();
            return View(succulent);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(SucculentCategoryManager.Select(), "SucculentCategoryID", "SucculentCategoryName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Succulent succulent)
        {
            if (ModelState.IsValid)
            {
                SucculentManager.Create(succulent);
                return RedirectToAction("Succulent_Details");
            }
            ViewBag.CategoryID = new SelectList(SucculentCategoryManager.Select(), "SucculentCategoryID", "SucculentCategoryName", succulent.CategoryID);
            return View(succulent);
        }
    }
    }
