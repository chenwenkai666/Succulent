using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace SucculentWeb.Controllers
{
    public class AdminManagementController : Controller
    {
        UsersManager uersmanager = new UsersManager();
        SucculentEntities db = new SucculentEntities();
        // GET: AdminManagement
        public ActionResult Index()
        {
            return View();
        }

    }
}