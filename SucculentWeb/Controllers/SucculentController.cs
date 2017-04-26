using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SucculentWeb.Controllers
{
    public class SucculentController : Controller
    {
        // GET: Succulent
        public ActionResult Succulent_Details()
        {
            return View();
        }
    }
}