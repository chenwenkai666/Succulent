﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SucculentWeb.ViewModels;
using Model;
using BLL;

namespace SucculentWeb.Controllers
{
    public class IndexController : Controller
    {
        SucculentEntities db = new SucculentEntities();
        GoodsManager goodsmanager = new GoodsManager();
        // GET: Index
        public ActionResult Index()
        {
            var succulent = db.Succulent.OrderByDescending(s=> s.CollectedTotal).Take(6);
            var goods = db.Goods.OrderByDescending(g=>g.LikeIt).Take(4);
            var shops = db.Shops.OrderByDescending(o=>o.SalesTotal).Take(3);
            indexVM indexvm = new ViewModels.indexVM();
            indexvm.succulent = succulent;
            indexvm.goods = goods;
            indexvm.shops =shops;
   
            var shop = db.Shops.OrderByDescending(p => p.SalesTotal).FirstOrDefault();
            ViewBag.photo = shop.ShopPhoto;
            return View(indexvm);
        }

        [HttpPost]
        public ActionResult SearchResult(string keywords)
        {
            ViewBag.KeyWords = keywords;
            SearchResultVM searchresultvm = new SearchResultVM();
            searchresultvm.Activity = ActivityManager.GetActivityByKeywords(keywords);
            searchresultvm.Goods = goodsmanager.SelectAllGoods().Where(g => g.GoodsName.Contains(keywords));
            searchresultvm.BaiKe = SucculentManager.SelectSucculent().Where(s =>( s.SucculentName.Contains(keywords)) ||(s.Feature.Contains(keywords) || (s.SucculentCategory.SucculentCategoryName.Contains(keywords)) ));
  

            return View(searchresultvm);
        }
    }
}