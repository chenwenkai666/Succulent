using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using SucculentWeb.Attributes;

namespace SucculentWeb.Controllers
{
    public class AdminManagementController : Controller
    {
        UsersManager usersmanager = new UsersManager();
        SucculentEntities db = new SucculentEntities();
        // GET: AdminManagement

        [IsLogIn(IsCheck =true)]
        public ActionResult Index()
        {
            Users admin = usersmanager.GetUserByName(Session["UserName"].ToString());
            if (admin.UserFlag != 0)
            {
                return Content("<script>alert('对不起，您无权访问该页面！');window.open('" + Url.Action("Index","Index") + "', '_self')</script>");
            }
            else
            {
                return View(admin);
            }
        }

    }
}