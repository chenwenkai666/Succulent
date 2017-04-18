using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace SucculentWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        #region 用户登录
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {
            int u = UsersManager.Login(user);
            if (u > 0)
            {
                Session["UserName"] = user.UserName;
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                return Content("<script>alert('用户名或密码错误！');window.open('" + Url.Content("~/User/Login") + "', '_self')</script>");
            }
        }
        #endregion

        #region 用户注册
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {
            try
            {
                var username = UsersManager.SelectUser(user.UserName);
                if (ModelState.IsValid && username!=null)
                {
                    string code = user.CheckCode;
                    if (code == Session["CheckCode"].ToString())
                    {
                        UsersManager.InsertUser(user);
                        return Content("<script>alert('注册成功！');window.open('" + Url.Content("~/User/Login") + "','_self');</script>");
                    }
                    else
                    {
                        return Content("<script>alert('验证码错误！');window.open('" + Url.Content("~/User/Registerdex") + "','_self');</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('验证信息出错，注册失败！');window.open('" + Url.Content("~/User/Register") + "','_self');</script>");
                }
            }
            catch(Exception ex)
            {
                return Content("<script>alert('系统出现错误，注册失败！');window.open('" + Url.Content("~/User/Register") + "', '_self')</script>");
            }
        }
        #endregion

        #region 验证码发送
        [HttpPost]
        public string CheckCode(string email)
        {
            if (email != "")
            {
                //随机生成6位数验证码
                System.Random a = new Random(System.DateTime.Now.Millisecond);
                int CheckCode = a.Next(100000, 999999);
                Session["CheckCode"] = CheckCode.ToString();
                MailHelper.SendEmail(email, "+社团会员注册验证", "您本次注册的验证码为：" + Session["CheckCode"] + ",20分钟内有效。请不要告诉他人哦~");
                return "验证码已发送至邮箱";
            }
            else
            {
                return "请输入有效的电子邮箱地址";
            }
        }
        #endregion

        #region 用户名检测
        [HttpPost]
        public string CheckUser(string UserName)
        {
            var result = UsersManager.SelectUser(UserName);
            if (result.Count()>0)
            {
                return "抱歉，该用户名已存在！";
            }
            else
            {
                return "恭喜，该用户名可以注册！";
            }
        }
        #endregion
    }
}