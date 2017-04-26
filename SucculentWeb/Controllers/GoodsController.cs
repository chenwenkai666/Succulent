using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

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
            string filePath = postImage.FileName;
            string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            string serverpath = Server.MapPath(@"\images\Goods\") + filename;
            string relativepath = @"/images/Goods/" + filename;
            postImage.SaveAs(serverpath);
            goods.GoodsPhoto = relativepath;
            goods.Flag = Convert.ToInt32( Request.Form["xuanze"]);
            db.Goods.Add(goods);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                return View(goods);
                 }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                throw dbEx ;
            }


        }
        public ActionResult index()
        {
            return View();
        }
    }
}