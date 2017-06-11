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
        SucculentEntities db = new SucculentEntities();
        GoodsManager goodsmanager = new GoodsManager();
        ShopManager shopmanager = new ShopManager();
        public ActionResult ShopMallIndex()
        {
            //var goods = db.Goods.Take(6);
            SucculentWeb.ViewModels.ShopMallIndexViewModels ShopMallIndex = new ShopMallIndexViewModels();
            ShopMallIndex.Succulent = goodsmanager.SelectTopSucculent();
            ShopMallIndex.Huapen = goodsmanager.SelectTopHuapen();
            ShopMallIndex.Zhiliao = goodsmanager.SelectTopZhiliao();
            ShopMallIndex.Gongju = goodsmanager.SelectTopGongju();
            ShopMallIndex.Penzai = goodsmanager.SelectTopPenzai();
            ShopMallIndex.Dingzhi = goodsmanager.SelectTopDingzhi();
            ShopMallIndex.HotSearch = goodsmanager.SelectHotSearch();
            ShopMallIndex.Shops = shopmanager.SelectTopShops();
            ShopMallIndex.NewGoods = goodsmanager.SelectTopTen();
            ShopMallIndex.HotGoods = goodsmanager.SelectTopHot();
            ShopMallIndex.hotGoods = goodsmanager.Select9to14();
            return View(ShopMallIndex);
        }
        public ActionResult ShopMallClass(string good )
        {
            SucculentWeb.ViewModels.ShopMallIndexViewModels ShopMallIndex = new ShopMallIndexViewModels();
            ShopMallIndex.Succulent = goodsmanager.SelectTopSucculent();
            ShopMallIndex.Huapen = goodsmanager.SelectTopHuapen();
            ShopMallIndex.Zhiliao = goodsmanager.SelectTopZhiliao();
            ShopMallIndex.Gongju = goodsmanager.SelectTopGongju();
            ShopMallIndex.Penzai = goodsmanager.SelectTopPenzai();
            ShopMallIndex.Dingzhi = goodsmanager.SelectTopDingzhi();
            ShopMallIndex.HotSearch = goodsmanager.SelectHotSearch();
            ShopMallIndex.Shops = shopmanager.SelectTopShops();
            return View(ShopMallIndex);
        }
        public ActionResult ShopMallShops()
        {
           
            SucculentWeb.ViewModels.ShopMallIndexViewModels ShopMallIndex = new ShopMallIndexViewModels();
            ShopMallIndex.Succulent = goodsmanager.SelectTopSucculent();
            ShopMallIndex.Huapen = goodsmanager.SelectTopHuapen();
            ShopMallIndex.Zhiliao = goodsmanager.SelectTopZhiliao();
            ShopMallIndex.Gongju = goodsmanager.SelectTopGongju();
            ShopMallIndex.Penzai = goodsmanager.SelectTopPenzai();
            ShopMallIndex.Dingzhi = goodsmanager.SelectTopDingzhi();
            ShopMallIndex.HotSearch = goodsmanager.SelectHotSearch();
            ShopMallIndex.Shops = shopmanager.SelectTopShops();
            ShopMallIndex.ShopMallShops = shopmanager.SelectAllShops();
            ShopMallIndex.ShopGoodsCount = shopmanager.SelectShopGoodsCount(2);
            ShopMallIndex.ShopMall4Goods = goodsmanager.SelectShopMall4Goods(2);
            return View(ShopMallIndex);
        }
        public ActionResult ShopMallClassContent(int ? page,string good)
        {
            Session["id"] = good;
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            IEnumerable<Goods> MallClass;
            switch (good)
            {
                case "1":
                     MallClass = goodsmanager.SelectMallZhiwu();
                    //return View(MallClass.ToPagedList(pageNumber, pageSize));
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }
                case "2":
                    MallClass= goodsmanager.SelectMallHuaqi();

                    //return View(MallClass.ToPagedList(pageNumber, pageSize));
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }
                case "3":
                    MallClass = goodsmanager.SelectMallZhiliao();
                    //return View(MallClass.ToPagedList(pageNumber, pageSize));
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }

                case "4":
                    MallClass = goodsmanager.SelectMallGongju();
                    //return View(MallClass.ToPagedList(pageNumber, pageSize));
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }

                case "5":
                    MallClass = goodsmanager.SelectMallZuhe();
                    //return View(MallClass.ToPagedList(pageNumber, pageSize));
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopMallClassContent", MallClass.ToPagedList(pageNumber, pageSize));
                    }
            }
            return Content("");
        }
        public ActionResult ShopMallShopsContent(int ? page)
        {
            //int shopid = Convert.ToInt32( forcle["shopID"]);
            //int shopid = Convert.ToInt32(Request.QueryString["shopID"]);
            //this.TempData["id"] = shopid;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var shop= shopmanager.SelectAllShops();
            if(Request.IsAjaxRequest())
            {
                return PartialView("ShopMallShopsContent", shop.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("ShopMallShopsContent", shop.ToPagedList(pageNumber, pageSize));
            }
           
        }
        public ActionResult ZhuXiao()
        {
            Session["UserName"] = null;
            Session["UserID"] = null;
            return RedirectToAction("ShopMallIndex","ShopMall");
        }
    }
}