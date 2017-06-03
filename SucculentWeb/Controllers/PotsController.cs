using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using SucculentWeb.Attributes;

namespace SucculentWeb.Controllers
{
    public class PotsController : Controller
    {
        // GET: Pots

        PotsManager potsmanager = new PotsManager();

        [IsLogIn(IsCheck =true)]
        public ActionResult Index()
        {
                Pots pots = potsmanager.GetPotsByUserID(int.Parse(Session["UserID"].ToString()));
                return View(pots);
        }

        [HttpPost]
        public ActionResult InsertPots()
        {
            if (Session["UserID"] != null)
            {
                Pots pots = new Pots();
                int userid = int.Parse(Session["UserID"].ToString());
                pots.UserID = userid;
                pots.LevelID = 1;
                pots.Experience = 1;
                if (potsmanager.InsertPots(pots))
                {
                    return Content("<script>alert('开通成功！');window.open('" + Url.Content("~/Pots/Index") + "', '_self')</script>");
                }
                else
                {
                    return Content("<script>alert('开通失败！');window.open('" + Url.Content("~/Pots/Index") + "', '_self')</script>");
                }

            }
            else
            {
                return Content("<script>alert('请先登录！');window.open('" + Url.Content("~/User/Login") + "', '_self')</script>");
            }
        }

        [HttpPost]
        public string Sign()
        {
            if (Session["UserID"] != null)
            {
                int userid = int.Parse(Session["UserID"].ToString());
                Pots pots = potsmanager.GetPotsByUserID(userid);
                DateTime oldsign;
                if (pots.Sign == null)
                {
                    oldsign = DateTime.Parse("2000-01-01");
                }
                else
                {
                    oldsign = DateTime.Parse(pots.Sign.ToString());
                }
                if (oldsign.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))//如果签到日期和当前日期相同则提示“已签到”
                {
                    return "您今天已经签过到了！";
                }
                else
                {
                    if (potsmanager.PotsSign(userid))
                    {
                        return "签到成功！";
                    }
                    else
                    {
                        return "签到系统维护中，签到失败！";
                    }
                }
            }
            else
            {
                return "请先登录！";
            }
        }
    }
}