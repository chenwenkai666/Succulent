﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SucculentWeb.Models;
using Model;

namespace SucculentWeb.Controllers
{
    public class IndexController : Controller
    {
        SucculentEntities db = new SucculentEntities();
        // GET: Index
        public ActionResult Index()
        {
            var succulent = db.Succulent.OrderByDescending(s=> s.CollectedTotal).Take(10);
            var goods = db.Goods.OrderByDescending(g=>g.LikeIt).Take(3);
            var shops = db.Shops.OrderByDescending(o=>o.SalesTotal).Take(3);
            indexVM indexvm = new Models.indexVM();
            indexvm.succulent = succulent;
            indexvm.goods = goods;
            indexvm.shops =shops;
   
            var shop = db.Shops.OrderByDescending(p => p.SalesTotal).FirstOrDefault();
            ViewBag.photo = shop.ShopPhoto;
            return View(indexvm);
        }
    }
}