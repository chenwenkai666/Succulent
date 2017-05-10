using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SucculentWeb.Controllers.Tribune
{
    public class TribuneBoardController : Controller
    {
        // GET: TribuneBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}