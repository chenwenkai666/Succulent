using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace SucculentWeb.Controllers
{
    public class LevelController : Controller
    {
        LevelManager levelmanager = new LevelManager();
        // GET: Level
        public ActionResult Index()
        {
            var levels= levelmanager.GetAllLevels();
            return View(levels);
        }
    }
}