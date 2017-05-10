using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using DAL;
using IDAL;
using DALFactory;
using PagedList;
namespace SucculentWeb.Controllers
{
    public class GoodsController : Controller
    {
        SucculentEntities db = new SucculentEntities();
        
        // GET: Goods
        public ActionResult CreatGoods()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatGoods(Goods goods)
        {
            try {

                HttpPostedFileBase postImage = Request.Files["GoodsPhoto"];
                string img = postImage.FileName.ToString();
                if (img =="")
                {
                    return Content("<script>;alert('请输入图片');history.go(-1)</script>");

                }
                else
                {
                    
                    string filePath = postImage.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\Goods\") + filename;
                    string relativepath = @"/images/Goods/" + filename;
                    postImage.SaveAs(serverpath);
                    goods.GoodsPhoto = relativepath;
                }
                if (ModelState.IsValid)
                { 
                 goods.Flag = Convert.ToInt32( Request.Form["xuanze"]);
                    goods.Time = DateTime.Now;
                db.Goods.Add(goods);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                    return Content("<script>;alert('添加成功');history.go(-1)</script>");
                }
                else
                {
                    return Content("<script>;alert('添加失败');history.go(-1)</script>");
                }
                return View(goods);
                 }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                throw dbEx ;
            }


        }

        public ActionResult Shops( int? page,int ShopID,string goods="2")
        {
            Session["shopid"] = ShopID;
            //ViewBag.id = ShopID ;
            int pageSize = 12;
            int pageNumber = (page ?? 1);          
            switch(goods)
            {
                case "1":
                    var good= GoodsManager.SelectShopLike(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                    
                case "2":
                    good= GoodsManager.SelectShopPrice(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "4":
                    good = GoodsManager.SelectShopTime(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "5":
                    good = GoodsManager.SelectShopDuorouZhiwu(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "6":
                    good = GoodsManager.SelectShopHuaqi(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "7":
                    good = GoodsManager.SelectShopGongju(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "8":
                    good = GoodsManager.SelectShopZhiliao(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "9":
                    good = GoodsManager.SelectShopZuhe(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
            }

            return Content("");
        }
        public ActionResult ShopTopImage(int ShopID)
        {
            ShopID =Convert.ToInt32( Session["shopid"]);
            var image = ShopManager.SelectShopTopImage(ShopID);
            return View(image);
        }
    }
}