using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using System.Data.Entity.Validation;
using SucculentWeb.ViewModels;

namespace SucculentWeb.Controllers
{
    public class UserCenterController : Controller
    {
        UsersManager usermanager = new UsersManager();
        CollectionManager collectionmanager = new CollectionManager();
        PostsManager postsmanager = new PostsManager();
        AttendanceManager attendancemanager = new  AttendanceManager();
        // GET: UserCenter
        public ActionResult Index(int id = 13)
        {
            var user = usermanager.GetUserByID(id);
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
            return PartialView(usercentervm);
        }

        public ActionResult UserInfo(int id)
        {
            var user = usermanager.GetUserByID(id);
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "你的宠物种类", Value = "你的宠物种类" });
            items.Add(new SelectListItem { Text = "你爸爸的名字", Value = "你爸爸的名字", Selected = true });
            items.Add(new SelectListItem { Text = "你最喜欢的颜色", Value = "你最喜欢的颜色" });
            this.ViewData["list"] = items;         
            return View(user);
        }


        public ActionResult UpdataPhoto(Users user)
        {             
              var u = usermanager.GetUserByID(user.UserID);
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
        [HttpGet]    
        public ActionResult UpdateInfo()
        {
            var u = usermanager.GetUserByID(int.Parse(Session["UserID"].ToString()));
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "你的宠物种类", Value = "你的宠物种类" });
            items.Add(new SelectListItem { Text = "你爸爸的名字", Value = "你爸爸的名字", Selected = true });
            items.Add(new SelectListItem { Text = "你最喜欢的颜色", Value = "你最喜欢的颜色" });
            this.ViewData["list"] = items;         
            return PartialView("UpdateInfo", u);
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
                if (Request.Form["list"] != null)
                {
                    u.SecretQues = Request.Form["list"];
                }
                else
                {
                    u.SecretQues =user.SecretQues ;
                }
                u.SecretAnws = user.SecretAnws;
                usermanager.UpdateUserInfo(u);
            }
            catch (DbEntityValidationException ex)
            {
                string error = ex.Message;

            }
            return PartialView("UpdateInfo", u);
        }

    }
}
