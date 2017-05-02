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
        // GET: Succulent
       //查找
        public ActionResult Succulent_Details()
        {
            var succulent = SucculentManager.SelectSucculent();
            return View(succulent);
        }
        [HttpGet]
        public ActionResult Create()
        {        
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

            return View(succulent);
        }
    }
    }
