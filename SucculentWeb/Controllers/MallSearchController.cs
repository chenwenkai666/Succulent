﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model;
using BLL;
namespace SucculentWeb.Controllers
{
    public class MallSearchController : Controller
    {
        // GET: MallSearch
        SucculentEntities db = new SucculentEntities();
        public ActionResult Index(string searchString,string currentFilter,int? page)
        {
            var goods = GoodsManager.SelectAllGoods();
            if(searchString!=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if(!String.IsNullOrEmpty(searchString))
            {
                goods = GoodsManager.SelectSearchGoods(searchString);
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(goods.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Tuijian()
        {
            var good = GoodsManager.SelectTuijian();
            return View(good);
        }
    }
}