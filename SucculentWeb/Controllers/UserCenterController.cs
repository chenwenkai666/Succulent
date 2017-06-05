using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
namespace SucculentWeb.Controllers
{
    public class UserCenterController : Controller
    {
        // GET: UserCenter
        public ActionResult Index(int id = 16)
        {
            var user = UsersManager.GetUserByID(id);

            return View(user);
        }
        public ActionResult UserInfo(int id)
        {
            var user = UsersManager.GetUserByID(id);
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "你的宠物种类", Value = "你的宠物种类" });
            items.Add(new SelectListItem { Text = "你爸爸的名字", Value = "你爸爸的名字", Selected = true });
            items.Add(new SelectListItem { Text = "你最喜欢的颜色", Value = "你最喜欢的颜色" });
            this.ViewData["list"] = items;         
            return View(user);
        }
        public ActionResult UpdataPhoto(Users user)
        {
            //Model.Users u = null;
      
            
              var u = UsersManager.GetUserByID(user.UserID);
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
                    //u.SecretQues = user.SecretQues;
                        UsersManager.UpdateUserInfo(u);
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
            var u = UsersManager.GetUserByID(user.UserID);
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "你的宠物种类", Value = "你的宠物种类" });
            items.Add(new SelectListItem { Text = "你爸爸的名字", Value = "你爸爸的名字", Selected = true });
            items.Add(new SelectListItem { Text = "你最喜欢的颜色", Value = "你最喜欢的颜色" });
            this.ViewData["list"] = items;
            u.Sex = user.Sex;
            if (user.Birth.ToString() == null)
            {
                u.Birth =Convert.ToDateTime("2017/01/01");
            }
            else
            {
               u.Birth = user.Birth;
            }          
            u.Phone = user.Phone;
            u.Email = user.Email;
            u.SecretAnws = user.SecretAnws;
            u.SecretQues = user.SecretQues;
            UsersManager.UpdateUserInfo(u);
            return View("UserInfo", u);
        }

        [HttpPost]
        public JsonResult UploadImage(HttpPostedFileBase image)
        {
            if (image != null)
            {
                string vPath = TempBasePicUrl + Guid.NewGuid().ToString() + ".png";
                string tempFilePath = Server.MapPath("~" + vPath);
                image.SaveAs(tempFilePath);
                return Json(new { success = true, result = vPath });
            }
            else {
                return Json(new { success = false, msg = "上传头像失败，请重新尝试！" });
            }
        }

        private string TempBasePicUrl
        {
            get
            {
                string temp = "/temp/";
                string dir = Server.MapPath("~" + temp);
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                return temp;
            }
        }

    }
}
