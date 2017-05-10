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
        //public ActionResult Register(Users user)
        //{
        //    try
        //    {
        //        var username = UsersManager.SelectUser(user.UserName);
        //        if (ModelState.IsValid && username!=null)
        //        {
        //            string code = user.CheckCode;
        //            if (code == Session["CheckCode"].ToString())
        //            {
        //                UsersManager.InsertUser(user);
        //                return Content("<script>alert('注册成功！');window.open('" + Url.Content("~/User/Login") + "','_self');</script>");
        //            }
        //            else
        //            {
        //                return Content("<script>alert('验证码错误！');window.open('" + Url.Content("~/User/Registerdex") + "','_self');</script>");
        //            }
        //        }
        //        else
        //        {
        //            return Content("<script>alert('验证信息出错，注册失败！');window.open('" + Url.Content("~/User/Register") + "','_self');</script>");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Content("<script>alert('系统出现错误，注册失败！');window.open('" + Url.Content("~/User/Register") + "', '_self')</script>");
        //    }
        //}
        #endregion

        #region 验证码发送
        //[HttpPost]
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

        #region 重置密码部分

        #region 忘记密码
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string UserName)
        {
            try
            {
                Users users = UsersManager.GetUser(UserName);
                if (users != null)
                {
                    return View("ResetWays", users);
                }
                else
                {
                    return Content("<script>alert('对不起，该用户名不存在！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
                }
            }
            catch
            {
                return Content("<script>alert('对不起，系统出现错误！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
            }

        }
        #endregion

        #region 选择重置方式
        public ActionResult ResetWays()
        {
            return View();
        }
        #endregion

        #region 密保问题验证
        public ActionResult SecretQuestion(string UserName)
        {
            Users users = UsersManager.GetUser(UserName);
            if (users != null)
            {
                if (users.SecretQues != null)
                {
                    return View(users);
                }
                else
                {
                    return Content("<script>alert('对不起，您没有设置密保问题，请选择其他验证方式！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
                }
            }
            else
            {
                return Content("<script>alert('对不起，该用户不存在！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SecretQuestion(string UserName, string SecretAnws)
        {
            Users users = UsersManager.GetUser(UserName);
            if (users != null)
            {
                if (users.SecretAnws == SecretAnws)
                {
                    return View("ResetPassword", users);
                }
                else
                {
                    return Content("<script>alert('对不起，密保问题答案错误！');window.open('" + Url.Action("SecretQuestion", "User", new { UserName = UserName }) + "','_self');</script>");
                }
            }
            else
            {
                return Content("<script>alert('对不起，该用户不存在！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
            }
        }
        #endregion

        #region 邮箱验证方式
        public ActionResult EmailValidate(string UserName)
        {
            Users users = UsersManager.GetUser(UserName);
            if (users != null)
            {
                if (users.Email != null)
                {
                    return View(users);
                }
                else
                {
                    return Content("<script>alert('对不起，您没有设置邮箱，请选择其他验证方式！');</script>");
                }
            }
            else
            {
                return Content("<script>alert('对不起，该用户不存在！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailValidate(string UserName, string Email, string CheckCode)
        {
            Users users = UsersManager.GetUser(UserName);
            if (users != null)
            {
                if (users.Email == Email)
                {
                    if (CheckCode == Session["CheckCode"].ToString())
                    {
                        return View("ResetPassword", users);
                    }
                    else
                    {
                        return Content("<script>alert('对不起，验证码错误！');window.open('" + Url.Action("EmailValidate", "User", new { UserName = UserName }) + "','_self');</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('对不起，电子邮箱与注册时不符！');window.open('" + Url.Action("EmailValidate", "User", new { UserName = UserName }) + "','_self');</script>");
                }
            }
            else
            {
                return Content("<script>alert('对不起，该用户不存在！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
            }
        }
        #endregion

        #region 手机号验证方式
        public ActionResult PhoneValidate(string UserName)
        {
            Users users = UsersManager.GetUser(UserName);
            if (users != null)
            {
                return View(users);
            }
            else
            {
                return Content("<script>alert('对不起，该用户不存在！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhoneValidate(string UserName, string Phone)
        {
            Users users = UsersManager.GetUser(UserName);
            if (users != null)
            {
                if (users.Phone == Phone)
                {
                    return View("ResetPassword", users);
                }
                else
                {
                    return Content("<script>alert('对不起，手机号与注册时不符！');window.open('" + Url.Action("PhoneValidate", "User", new { UserName = UserName }) + "','_self');</script>");
                }
            }
            else
            {
                return Content("<script>alert('对不起，该用户不存在！');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
            }
        }
        #endregion

        #region 重置密码
        public ActionResult ResetPassword(string UserName)
        {
            Users users = UsersManager.GetUser(UserName);
            if (users != null)
            {
                return View(users);
            }
            else
            {
                return Content("<script>alert('对不起，该用户不存在！');</script>");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(string UserName, string Password, string Phone, string Email, string PasswordAgain)
        {
            try
            {
                Users users = UsersManager.GetUser(UserName);
                users.Password = Password;
                //users.PasswordAgain = PasswordAgain;
                //users.CheckCode = "000";
                users.Phone = Phone;
                users.Email = Email;
                UsersManager.UpdateUserInfo(users);
                return Content("<script>alert('密码重置成功！请牢记密码');window.open('" + Url.Action("Login", "User") + "','_self');</script>");

            }
            catch (Exception ex)
            {
                return Content("<script>alert('对不起，系统出错！原因如下：" + ex.Message + "');window.open('" + Url.Action("ForgetPassword", "User") + "','_self');</script>");
            }
        }
        #endregion

        #endregion
    }
}