using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SucculentWeb.ViewModels;
using Model;
using PagedList;
using BLL;

namespace SucculentWeb.Controllers
{
    public class SucculentIndexController : Controller
    {
        SucculentManager succulentmanager = new SucculentManager();
        SucculentCategoryManager succulentcategorymanager = new SucculentCategoryManager();
        public ActionResult Succulent()
        {
            ViewBag.CategoryID = new SelectList(succulentcategorymanager.Select(), "SucculentCategoryID", "SucculentCategoryName");
            var category = succulentcategorymanager.Select();
            return View(category);
        }             
        public ActionResult PartialViewDate(int? page,int SucculentCategoryID=0,string SearchSucculent = null)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);                    
            var succulent = succulentmanager.SelectSucculent();
            if (Request.IsAjaxRequest())
            {
                if (SucculentCategoryID == 0&&SearchSucculent== null)
               {
                
                return PartialView("PartialViewDate", succulent.OrderByDescending(s =>s.CollectedTotal).ToPagedList(pageNum, pageSize));
               }
                else
                {
                    if(SearchSucculent == null)
                    {
                    var Csucculent= succulentmanager.SelectSucculentByCatogaryid(SucculentCategoryID);                  
                    return PartialView("PartialViewDate", Csucculent.OrderByDescending(s => s.CollectedTotal).ToPagedList(pageNum, pageSize));
                    }
                    else
                    {
                        var SchSucculent = succulentmanager.SelectBySearchName(SearchSucculent);
                        return PartialView("PartialViewDate", SchSucculent.OrderByDescending(s => s.CollectedTotal).ToPagedList(pageNum, pageSize));
                    }
                   
                }

            }
            else
            {
                return View("PartialViewDate", succulent.OrderByDescending(s => s.CollectedTotal).ToPagedList(pageNum, pageSize));
            }
        }

        public ActionResult CategoryContent(int SucculentCategoryID=1)
        {
            var category= succulentcategorymanager.SelectByID(SucculentCategoryID);
            return PartialView("CategoryContent",category);
        }

    }
}