using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using System.Data.Entity.Validation;
using SucculentWeb.ViewModels;
using SucculentWeb.Attributes;

namespace SucculentWeb.Controllers
{
    [IsLogIn(IsCheck =true)]
    public class UserCenterController : Controller
    {
        UsersManager usermanager = new UsersManager();
        CollectionManager collectionmanager = new CollectionManager();
        PostsManager postsmanager = new PostsManager();
        AttendanceManager attendancemanager = new  AttendanceManager();
        OrderItemsManager orderitemsmanager = new OrderItemsManager();
        PotsManager potsmanager = new PotsManager();
        // GET: UserCenter
        public ActionResult Index(int id = 13)
        {
            var user = usermanager.GetUserByID(int.Parse(Session["UserID"].ToString()));
            return View(user);
        }

        public ActionResult IndexPartial(string Section="帖子")
        {
            
            ViewBag.Section = Section;
            int UserID = int.Parse(Session["UserID"].ToString());
            UserCenterVM usercentervm = new ViewModels.UserCenterVM();
            usercentervm.attendance = attendancemanager.SelectAllAttendanceByUserID(UserID);
            usercentervm.collection=collectionmanager.SelectByUserID(UserID);
            usercentervm.post = postsmanager.SelectAllPostsByUserID(UserID);
            usercentervm.orderitems = orderitemsmanager.SelectAllOrderItems(UserID);
            return PartialView(usercentervm);
        }

        public ActionResult PotsIndex()
        {
            Pots pots = potsmanager.GetPotsByUserID(int.Parse(Session["UserID"].ToString()));
            return PartialView(pots);
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
                Pots userpots = potsmanager.GetPotsByUserID(userid);
                if (userpots == null)
                {
                    if (potsmanager.InsertPots(pots))
                    {
                        return Content("<script>alert('开通成功！');window.open('" + Url.Content("~/UserCenter/Index") + "', '_self')</script>");
                    }
                    else
                    {
                        return Content("<script>alert('开通失败！');window.open('" + Url.Content("~/UserCenter/Index") + "', '_self')</script>");
                    }
            }
            else
            {
                return Content("<script>alert('您已经开通过啦，不能重复开通哦！');window.open('" + Url.Content("~/UserCenter/Index") + "', '_self')</script>");
            }
        }
            else
            {
                return Content("<script>alert('请先登录！');window.open('" + Url.Content("~/UserCenter/Index") + "', '_self')</script>");
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


        [HttpGet]
        public ActionResult UserInfo(int id)
        {
            var user = usermanager.GetUserByID(id);
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "你的宠物种类", Value = "你的宠物种类" });
            items.Add(new SelectListItem { Text = "你爸爸的名字", Value = "你爸爸的名字"});
            items.Add(new SelectListItem { Text = "你最喜欢的颜色", Value = "你最喜欢的颜色" });           
            this.ViewData["list"] = items;         
            return View(user);
        }


        public ActionResult UpdataPhoto()
        {             
              var u = usermanager.GetUserByID(int.Parse(Session["UserID"].ToString()));
                try
                {

                    HttpPostedFileBase postImage = Request.Files["Photo"];
                    string img = postImage.FileName.ToString();
                    if (img == "")
                    {
                        return Content("<script>;alert('请输入图片');history.go(-1)</script>");

                    }
                    else
                    {

                        string filePath = postImage.FileName;
                        string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath(@"\images\Photo\") + filename;
                        string relativepath = @"/images/Photo/" + filename;
                        postImage.SaveAs(serverpath);
                        u.Photo = relativepath;
                    List<SelectListItem> items = new List<SelectListItem>();
                    items.Add(new SelectListItem { Text = "你的宠物种类", Value = "你的宠物种类" });
                    items.Add(new SelectListItem { Text = "你爸爸的名字", Value = "你爸爸的名字", Selected = true });
                    items.Add(new SelectListItem { Text = "你最喜欢的颜色", Value = "你最喜欢的颜色" });
                    this.ViewData["list"] = items;
                    usermanager.UpdateUserInfo(u);
                    }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    throw dbEx;
                }
           
            return View("UserInfo", u);
        }         
        [HttpPost]
        public ActionResult UpdateInfo(Users user)
        {
            Users u = usermanager.GetUserByID(int.Parse(Session["UserID"].ToString()));
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "你的宠物种类", Value = "你的宠物种类" });
                items.Add(new SelectListItem { Text = "你爸爸的名字", Value = "你爸爸的名字", Selected = true });
                items.Add(new SelectListItem { Text = "你最喜欢的颜色", Value = "你最喜欢的颜色" });
                this.ViewData["list"] = items;
                u.Sex = user.Sex;
                if (user.Birth.ToString() == null)
                {
                    u.Birth = Convert.ToDateTime("2017/01/01");
                }
                else
                {
                    u.Birth = user.Birth;
                }
                u.Phone = user.Phone;
                u.Email = user.Email;
                u.SecretQues = user.SecretQues;
                u.SecretAnws = user.SecretAnws;             
                usermanager.UpdateUserInfo(u);
            }
            catch (DbEntityValidationException ex)
            {
                string error = ex.Message;

            }
           return  View("UserInfo", u);
        }

    }
}
