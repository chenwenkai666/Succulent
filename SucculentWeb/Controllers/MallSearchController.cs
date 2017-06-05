using System;
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
        GoodsManager goodsmanager = new GoodsManager();
        public ActionResult Index(string searchString,string currentFilter,int? page)
        {
            var goods = goodsmanager.SelectAllGoods();
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
                goods = goodsmanager.SelectSearchGoods(searchString);
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if(Request.IsAjaxRequest())
            {
                return PartialView("MallSearch", goods.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(goods.ToPagedList(pageNumber, pageSize));
            }
            
        }
        public ActionResult MallSearchContent(string searchString, string currentFilter, int? page)
        {
            var goods = goodsmanager.SelectAllGoods();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                goods = goodsmanager.SelectSearchGoods(searchString);
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("MallSearchContent", goods.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(goods.ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult Tuijian()
        {
            var good = goodsmanager.SelectTuijian();
            return View(good);
        }
    }
}