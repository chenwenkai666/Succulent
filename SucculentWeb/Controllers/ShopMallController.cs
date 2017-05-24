using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using IDAL;
using DALFactory;
using Model;
using SucculentWeb.ViewModels;
using PagedList;
namespace SucculentWeb.Controllers
{
    public class ShopMallController : Controller
    {
        // GET: ShopMall
        //SucculentEntities db = new SucculentEntities();
        public ActionResult ShopMallIndex()
        {
            //var goods = db.Goods.Take(6);
            SucculentWeb.ViewModels.ShopMallIndexViewModels ShopMallIndex = new ShopMallIndexViewModels();
            ShopMallIndex.Succulent = GoodsManager.SelectTopSucculent();
            ShopMallIndex.Huapen = GoodsManager.SelectTopHuapen();
            ShopMallIndex.Zhiliao = GoodsManager.SelectTopZhiliao();
            ShopMallIndex.Gongju = GoodsManager.SelectTopGongju();
            ShopMallIndex.Penzai = GoodsManager.SelectTopPenzai();
            ShopMallIndex.Dingzhi = GoodsManager.SelectTopDingzhi();
            ShopMallIndex.HotSearch = GoodsManager.SelectHotSearch();
            ShopMallIndex.Shops = ShopManager.SelectTopShops();
            ShopMallIndex.NewGoods = GoodsManager.SelectTopTen();
            ShopMallIndex.HotGoods = GoodsManager.SelectTopHot();
            ShopMallIndex.hotGoods = GoodsManager.Select9to14();
            return View(ShopMallIndex);
        }
        public ActionResult ShopMallClass(string good )
        {
            SucculentWeb.ViewModels.ShopMallIndexViewModels ShopMallIndex = new ShopMallIndexViewModels();
            ShopMallIndex.Succulent = GoodsManager.SelectTopSucculent();
            ShopMallIndex.Huapen = GoodsManager.SelectTopHuapen();
            ShopMallIndex.Zhiliao = GoodsManager.SelectTopZhiliao();
            ShopMallIndex.Gongju = GoodsManager.SelectTopGongju();
            ShopMallIndex.Penzai = GoodsManager.SelectTopPenzai();
            ShopMallIndex.Dingzhi = GoodsManager.SelectTopDingzhi();
            ShopMallIndex.HotSearch = GoodsManager.SelectHotSearch();
            ShopMallIndex.Shops = ShopManager.SelectTopShops();
            return View(ShopMallIndex);
        }
        public ActionResult ShopMallShops()
        {
           
            SucculentWeb.ViewModels.ShopMallIndexViewModels ShopMallIndex = new ShopMallIndexViewModels();
            ShopMallIndex.Succulent = GoodsManager.SelectTopSucculent();
            ShopMallIndex.Huapen = GoodsManager.SelectTopHuapen();
            ShopMallIndex.Zhiliao = GoodsManager.SelectTopZhiliao();
            ShopMallIndex.Gongju = GoodsManager.SelectTopGongju();
            ShopMallIndex.Penzai = GoodsManager.SelectTopPenzai();
            ShopMallIndex.Dingzhi = GoodsManager.SelectTopDingzhi();
            ShopMallIndex.HotSearch = GoodsManager.SelectHotSearch();
            ShopMallIndex.Shops = ShopManager.SelectTopShops();
            ShopMallIndex.ShopMallShops = ShopManager.SelectAllShops();
            ShopMallIndex.ShopGoodsCount = ShopManager.SelectShopGoodsCount(2);
            ShopMallIndex.ShopMall4Goods = GoodsManager.SelectShopMall4Goods(2);
            return View(ShopMallIndex);
        }
        public ActionResult ShopMallClassContent(int ? page,string good)
        {
            Session["id"] = good;
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            switch (good)
            {
                case "1":
                    var MallClass = GoodsManager.SelectMallZhiwu();
                    return View(MallClass.ToPagedList(pageNumber,pageSize));
                case "2":
                    MallClass = GoodsManager.SelectMallHuaqi();
                    return View(MallClass.ToPagedList(pageNumber, pageSize));

                case "3":
                    MallClass = GoodsManager.SelectMallZhiliao();
                    return View(MallClass.ToPagedList(pageNumber, pageSize));

                case "4":
                    MallClass = GoodsManager.SelectMallGongju();
                    return View(MallClass.ToPagedList(pageNumber, pageSize));

                case "5":
                    MallClass = GoodsManager.SelectMallZuhe();
                    return View(MallClass.ToPagedList(pageNumber, pageSize));
            }
            return Content("");
        }
        public ActionResult ShopMallShopsContent(int ? page,FormCollection forcle)
        {
            int shopid = Convert.ToInt32( forcle["shopID"]);
            //int shopid =Convert.ToInt32( Request.QueryString["shopID"]);
            this.TempData["id"] = shopid;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var shop= ShopManager.SelectAllShops();
            return View(shop.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult ShopMallShopsCount()
        {
            int shopid =Convert.ToInt32( this.TempData["id"]);      
            ViewData["count"]= ShopManager.SelectShopGoodsCount(2);
            return View();
        }
        public ActionResult ShopMallShopsImage()
        {
            int shopid = Convert.ToInt32(this.TempData["id"]);
            var good= GoodsManager.SelectShopMall4Goods(2);
            return View(good);
        }
    }
}