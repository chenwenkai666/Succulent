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
using SucculentWeb.ViewModels;
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
        public ActionResult GoodsDetail(int goodid)
        {
           Session["goodid"]= goodid;
            //SucculentWeb.ViewModels.GoodDetailViewModel Gooddetail = new GoodDetailViewModel();
            //Gooddetail.GoodDetail= GoodsManager.SelectGoodDetail(2);
            var goodDetail = GoodsManager.SelectGoodDetail(goodid);
            ViewBag.goodphoto = goodDetail.GoodsPhoto;
            ViewBag.goodprice = goodDetail.Price;
            ViewBag.goodlikit = goodDetail.LikeIt;
            ViewBag.time = goodDetail.Time;
            ViewBag.goodName = goodDetail.GoodsName;
            ViewBag.goodDes = goodDetail.GoodsDescribe;
            return View();
        }
        public ActionResult GoodsDetailShop(int goodid)
        {
            goodid = Convert.ToInt32(Session["goodid"]);
            var shopdetail = ShopManager.SelectShopDetail(goodid);
            ViewBag.shopname = shopdetail.ShopName;
            ViewBag.username = shopdetail.Users.UserName;
            return View();
        }
        public ActionResult GoodsDetailTuijian(int goodid)
        {
            goodid= Convert.ToInt32(Session["goodid"]);
            var DetailTuijian = GoodsManager.SelectDetailTuijianGoodid(goodid);
            Session["Detailshopid"] = DetailTuijian.ShopID;
            var detail = GoodsManager.SelectDetailTuijian8Goods(DetailTuijian.ShopID);
            return View(detail);
        }
        public ActionResult DetailTopImage (int goodid)
        {
            goodid = Convert.ToInt32(Session["goodid"]);
            var DetailTuijian = GoodsManager.SelectDetailTuijianGoodid(goodid);
            Session["Detailshopid"] = DetailTuijian.ShopID;
            var topimage = ShopManager.SelectDetailTopImage(DetailTuijian.ShopID);
            ViewBag.topimage = topimage.TopImage;
            return View();
        }
        public ActionResult GoodsComments(int goodid)
        {
            goodid= Convert.ToInt32(Session["goodid"]);
            var comment = (from p in db.GoodsComments
                           where p.GoodsID == goodid select p).OrderBy(p => p.PublishTime);
                          
            return View(comment);
        }
        [HttpPost]
        public ActionResult Comments(GoodsComments GoodsComments )
        {
            int goodid = Convert.ToInt32(Session["goodid"]);
            string textarea = Request["pingluntextarea"];
            if(ModelState.IsValid)
            {
                GoodsComments.UserID = 1;
                GoodsComments.GoodsID = goodid;
                GoodsComments.PublishTime = System.DateTime.Now;
                GoodsComments.GoodsCommentContent = textarea;
                db.GoodsComments.Add(GoodsComments);
                db.SaveChanges();
                return Content("<script>;alert('评论成功!');history.go(-1)</script>");
            }
            return RedirectToAction("GoodsComments", "Goods");
        }
        public ActionResult RegisterShops()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterShops(Shops shops)
        {
            try { 
                
                HttpPostedFileBase shopphoto = Request.Files["ShopPhoto"];
                HttpPostedFileBase shoptopimg = Request.Files["ShopTopImg"];
                string img1 = shopphoto.FileName.ToString();
                string img2 = shoptopimg.FileName.ToString();
                if(img1=="")
                {
                    return Content("<script>;alert('请输入商店图标');history.go(-1)</script>");
                }
                else
                {

                    string filePath = shopphoto.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\Goods\") + filename;
                    string relativepath = @"/images/Goods/" + filename;
                    shopphoto.SaveAs(serverpath);
                    shops.ShopPhoto = relativepath;
                }
                if (img2=="")
                {
                    return Content("<script>;alert('请输入商店顶部横幅图片');history.go(-1)</script>");
                }
                else
                {

                    string filePath = shoptopimg.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\Goods\") + filename;
                    string relativepath = @"/images/Goods/" + filename;
                    shoptopimg.SaveAs(serverpath);
                    shops.TopImage = relativepath;
                }
                if(ModelState.IsValid)
                {
                    shops.UserID = 1;
                    db.Shops.Add(shops);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                    return Content("<script>;alert('添加成功');history.go(-1)</script>");
                }
                else
                {
                    return Content("<script>;alert('添加失败');history.go(-1)</script>");
                }
            
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
            return View();
        }
    }
}