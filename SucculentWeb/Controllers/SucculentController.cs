using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using SucculentWeb.ViewModels;
using BLL;
using System.Data.Entity;

namespace SucculentWeb.Controllers
{
    public class SucculentController : Controller
    {
        SucculentManager succulentmanager = new SucculentManager();
        SucculentCategoryManager succulentcategorymanager = new SucculentCategoryManager();
        CollectionManager collectionmanager = new CollectionManager();
        LookManager lookmanager = new LookManager();
        public ActionResult Succulent()
        {
            return View();
        }
       
        public ActionResult Succulent_Details(int id=18, int categoryid=1)
        {

            var details = succulentmanager.SelectSucculentBySucculentid(id);
            var room = succulentmanager.SelectRoomSucculent();
            SucculentIndexViewModels si = new ViewModels.SucculentIndexViewModels();
            si.succulent_Details = details;
            si.Room = room;
            //用于给用户不存在的情况提供数据
            var lookc = lookmanager.NewSelectByCategoryID(categoryid);
            if (Session["UserID"] != null)
            {
                //用于给用户存在的情况提供数据
                var succulentlook = lookmanager.NewSelectByUserID(int.Parse(Session["UserID"].ToString())).ToList();
                Look look = new Look();              
                var succulent1 = succulentmanager.SelectByID(id);
                var l = lookmanager.NewSelectbySucculentId(id);
                Look userlook = l.Where(a => a.UserID == int.Parse(Session["UserID"].ToString())).FirstOrDefault();              
                if (userlook == null)
                {
                    //不存在则插入新的记录look
                    look.SucculentID = succulent1.SucculentID;
                    look.UserID = int.Parse(Session["UserID"].ToString());
                    look.SucculentCategoryID = succulent1.CategoryID;
                    if (look.LookNum == null)
                    {
                        look.LookNum = 0;
                    }
                   look.LookNum += 1;        
                    lookmanager.NewCreate(look);
                }
                else
                {
                    //存在记录，则直接修改userlook的LookNum字段
                    if (userlook.LookNum == null)
                    {
                        userlook.LookNum = 0;
                    }
                        userlook.LookNum += 1;
                        lookmanager.NewUpdateAdd(userlook);
                }
                si.Like = succulentlook;
            }

            else
            {
                si.Like = lookc;

            }
            return View("Succulent_Details", si);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(succulentcategorymanager.Select(), "SucculentCategoryID", "SucculentCategoryName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Succulent succulent)
        {
            if (ModelState.IsValid)
            {
                if (succulentmanager.SelectName(succulent.SucculentName) == null)
                {
                    succulentmanager.Create(succulent);
                    return RedirectToAction("Succulent_Details");
                }
                else
                {
                    return Content("<script>alert('该多肉已经存在');window.open('" + Url.Content("~/Succulent/Create") + "', '_self')</script>");
                }
                
            }
            ViewBag.CategoryID = new SelectList(succulentcategorymanager.Select(), "SucculentCategoryID", "SucculentCategoryName", succulent.CategoryID);
            return View(succulent);
        }      
        [HttpPost]
        public string Collection(int id)
        {
            Collection collection=new Collection();
            var succulent = succulentmanager.SelectByID(id);         
            if (Session["UserID"] == null)
            {
                //return Content("<script>alert('请先登录哦！');window.open('" + Url.Content("~/User/Login") + "', '_self')</script>");
                return "请先登录哦！";
            }
            else {
                var c=collectionmanager.SelectbySucculentId(id);
                Collection usercollection = c.Where(a => a.UserID == int.Parse(Session["UserID"].ToString())).FirstOrDefault();
                if (usercollection==null )
                { 
                    collection.SucculentID = succulent.SucculentID;
                    collection.UserID = int.Parse(Session["UserID"].ToString());
                    collection.CollectionTime = DateTime.Now;
                    collectionmanager.Create(collection);
                    succulent.CollectedTotal += 1;
                    succulentmanager.UpdateAdd(succulent);
                    return succulent.CollectedTotal.ToString();
                }
               
                else
                {
                    //return Content("<script>alert('你已经收藏过啦！');location=location;</script>");/*window.location.reload();*/
                    return "你已经收藏过啦！";
                }
                //return View(succulent);
                
            }
           
        }  
    }
    }
