using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using SucculentWeb.ViewModels;
using BLL;
using System.Data.Entity;

namespace SucculentWeb.Controllers
{
    public class SucculentController : Controller
    {

        public ActionResult Succulent()
        {
            return View();
        }
       
        public ActionResult Succulent_Details(int id=18, int categoryid=1)
        {
            var details = SucculentManager.SelectSucculentBySucculentid(id);
            var succulent =BLL.SucculentManager.SelectSucculentByCatogaryid(categoryid);
            var room = BLL.SucculentManager.SelectRoomSucculent();
            SucculentIndexViewModels si = new ViewModels.SucculentIndexViewModels();
            si.succulent_Details = details;
            si.Like = succulent;
            si.Room = room;
            return View("Succulent_Details", si);
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
        [HttpPost]
        public int UpdateAdd(int id,bool flag)
        {
            var succulent =SucculentManager.SelectByID(id);
            if (!flag)
            {
                succulent.CollectedTotal += 1;
                SucculentManager.UpdateAdd(succulent);
            }           
            return int.Parse((succulent.CollectedTotal).ToString());
        }    
    }
    }
