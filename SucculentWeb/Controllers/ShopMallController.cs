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
    }
}