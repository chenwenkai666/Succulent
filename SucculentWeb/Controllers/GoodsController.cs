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
        ReplyGoodsManager replygoodmanager = new ReplyGoodsManager();
        GoodsCommentsManager goodscommentsmanager = new GoodsCommentsManager();
        GoodsManager goodsmanager = new GoodsManager();
        AddressManager addressmanager = new AddressManager();
        AdoptResultManager adoptresultmanager = new AdoptResultManager();
        OrderItemsManager orderitemsmanager = new OrderItemsManager();
        OrdersManager ordersmanager = new OrdersManager();
        ShopManager shopmanager = new ShopManager();
        ShoppingCartsManager shoppingcarsmanager = new ShoppingCartsManager();
        AdoptManager adoptmanager = new AdoptManager();
        // GET: Goods
        public ActionResult CreatGoods()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreatGoods(Goods goods)
        {
            try
            {

                HttpPostedFileBase postImage = Request.Files["GoodsPhoto"];
                string img = postImage.FileName.ToString();
                if (img == "")
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
                    int userid = Convert.ToInt32(Session["UserID"]);
                    goods.ShopID = shopmanager.SelectShopid(userid);
                    goods.Flag = Convert.ToInt32(Request.Form["xuanze"]);
                    goods.Time = DateTime.Now;
                    goodsmanager.CreateGoods(goods);
                    return Content("<script>;alert('添加成功');history.go(-1)</script>");
                }
                else
                {
                    return Content("<script>;alert('添加失败');history.go(-1)</script>");
                }
                return View(goods);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                throw dbEx;
            }


        }

        public ActionResult Shops(int? page, int ShopID, string goods = "2")
        {
            Session["shopid"] = ShopID;
            //ViewBag.id = ShopID ;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            switch (goods)
            {
                case "1":
                    var good = goodsmanager.SelectShopLike(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));

                case "2":
                    good = goodsmanager.SelectShopPrice(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "4":
                    good = goodsmanager.SelectShopTime(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "5":
                    good = goodsmanager.SelectShopDuorouZhiwu(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "6":
                    good = goodsmanager.SelectShopHuaqi(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "7":
                    good = goodsmanager.SelectShopGongju(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "8":
                    good = goodsmanager.SelectShopZhiliao(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
                case "9":
                    good = goodsmanager.SelectShopZuhe(ShopID);
                    return View(good.ToPagedList(pageNumber, pageSize));
            }

            return Content("");
        }
        public ActionResult ShopsContent(int? page, int ShopID, string goods = "2")
        {
            Session["shopid"] = ShopID;
            //ViewBag.id = ShopID ;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            switch (goods)
            {
                case "1":
                    var good = goodsmanager.SelectShopLike(ShopID);
                    if(Request.IsAjaxRequest())
                    {
                        return PartialView("ShopsContent",good.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }

                case "2":
                    good = goodsmanager.SelectShopPrice(ShopID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                case "4":
                    good = goodsmanager.SelectShopTime(ShopID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                case "5":
                    good = goodsmanager.SelectShopDuorouZhiwu(ShopID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                case "6":
                    good = goodsmanager.SelectShopHuaqi(ShopID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                case "7":
                    good = goodsmanager.SelectShopGongju(ShopID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                case "8":
                    good = goodsmanager.SelectShopZhiliao(ShopID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                case "9":
                    good = goodsmanager.SelectShopZuhe(ShopID);
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View("ShopsContent", good.ToPagedList(pageNumber, pageSize));
                    }
            }

            return Content("");
        }
        public ActionResult ShopTopImage(int ShopID)
        {
            ShopID = Convert.ToInt32(Session["shopid"]);
            var image = shopmanager.SelectShopTopImage(ShopID);
            return View(image);
        }
        public ActionResult GoodsDetail(int goodid)
        {
            Session["goodid"] = goodid;
            int Goodid = Convert.ToInt32(Session["goodid"]);
            var goodDetail = goodsmanager.SelectGoodDetail(goodid);
            ViewBag.goodphoto = goodDetail.GoodsPhoto;
            ViewBag.goodprice = goodDetail.Price;
            ViewBag.goodlikit = goodDetail.LikeIt;
            ViewBag.time = goodDetail.Time;
            ViewBag.goodName = goodDetail.GoodsName;
            ViewBag.goodDes = goodDetail.GoodsDescribe;
            ViewBag.KuCun = goodDetail.Stock;
            ViewBag.pinglunshu = goodscommentsmanager.GoodsCommentsCounts(Goodid);
            ViewBag.Sales = goodDetail.Sales;
            return View();
        }
        public ActionResult GoodsDetailShop(int goodid)
        {
            goodid = Convert.ToInt32(Session["goodid"]);
            var shopdetail = shopmanager.SelectShopDetail(goodid);
            ViewBag.shopname = shopdetail.ShopName;
            ViewBag.username = shopdetail.Users.UserName;
            return View();
        }
        public ActionResult GoodsDetailTuijian(int goodid)
        {
            goodid = Convert.ToInt32(Session["goodid"]);
            var DetailTuijian = goodsmanager.SelectDetailTuijianGoodid(goodid);
            Session["Detailshopid"] = DetailTuijian.ShopID;
            var detail = goodsmanager.SelectDetailTuijian8Goods(DetailTuijian.ShopID);
            return View(detail);
        }
        public ActionResult DetailTopImage(int goodid)
        {
            goodid = Convert.ToInt32(Session["goodid"]);
            var DetailTuijian = goodsmanager.SelectDetailTuijianGoodid(goodid);
            Session["Detailshopid"] = DetailTuijian.ShopID;
            var topimage = shopmanager.SelectDetailTopImage(DetailTuijian.ShopID);
            ViewBag.topimage = topimage.TopImage;
            return View();
        }
        public ActionResult GoodsComments(int ? page,int goodid)
        {
            goodid = Convert.ToInt32(Session["goodid"]);
            var comment = goodscommentsmanager.SelectGoodsComment(goodid);
            return View(comment);
          
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Comments(GoodsComments GoodsComments)
        {
            int goodid = Convert.ToInt32(Session["goodid"]);
            int userid = Convert.ToInt32(Session["UserID"]);
            string textarea = Request["pingluntextarea"];
            var result = orderitemsmanager.GoodCommentOrder(userid,goodid);
            if (ModelState.IsValid)
            {
                if(result>0)
                {
                    if(textarea!="")
                    {
                       GoodsComments.UserID = Convert.ToInt32(Session["UserID"]);
                       GoodsComments.GoodsID = goodid;
                       GoodsComments.PublishTime = System.DateTime.Now;
                       GoodsComments.GoodsCommentContent = textarea;
                        goodscommentsmanager.InsertGoodsComment(GoodsComments);
                        return Content("<script>alert('评论成功');window.open('" + Url.Action("GoodsDetail", "Goods", new { goodid=goodid }) + "', '_self')</script>");
                    }
                    else
                    {
                        return Content("<script>alert('评论不能为空！');history.go(-1)</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('您未购买此商品，不能评论！');history.go(-1)</script>");
                }
            }
            return RedirectToAction("GoodsDetail", "Goods", new { goodid = goodid });
        }
        public ActionResult ReplyGoodComments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReplyGoodComments(int GoodsCommentid, ReplyGoods replyGoods)
        {
            string replytext = Request.Form["textarea1"];
            if (replytext =="")
            {
                return Content("<script>;alert('回复不能为空');history.go(-1)</script>");
            }
            else
            {
                int goodid = Convert.ToInt32(Session["goodid"]);
                int userid= Convert.ToInt32(Session["UserID"]);
            replyGoods.GoodsCommentID = GoodsCommentid;
            replyGoods.UserID = userid;
            replyGoods.ReplyContent = replytext;
            replyGoods.ReplyTime = DateTime.Now;
            replygoodmanager.InsertReplyGoods(replyGoods);
                //return Content("<script>alert('回复成功！');history.go(-1)</script>");
                return Content("<script>alert('回复成功');window.open('" + Url.Action("GoodsDetail", "Goods", new { goodid = goodid }) + "', '_self')</script>");
            }
        }
        public ActionResult RegisterShops()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RegisterShops(Shops shops)
        {
            try
            {

                HttpPostedFileBase shopphoto = Request.Files["ShopPhoto"];
                HttpPostedFileBase shoptopimg = Request.Files["ShopTopImg"];
                string img1 = shopphoto.FileName.ToString();
                string img2 = shoptopimg.FileName.ToString();
                if (img1 == "")
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
                if (img2 == "")
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
                if (ModelState.IsValid)
                {
                    int userid= Convert.ToInt32(Session["UserID"]);
                    shops.UserID = Convert.ToInt32(Session["UserID"]);
                    var result = (from p in db.Shops where p.UserID == userid select p).Count();
                    if(result>0)
                    {
                        return Content("<script>alert('您已注册商店，请不要重复注册！');history.go(-1)</script>");
                    }
                    else
                    {
                        shopmanager.CreateNewShops(shops);
                    return Content("<script>;alert('注册成功');history.go(-1)</script>");
                    }
                }
                else
                {
                    return Content("<script>;alert('注册失败');history.go(-1)</script>");
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
            return View();
        }
        public ActionResult Carts(int UserID)
        {
            UserID = Convert.ToInt32(Session["UserID"]);
            var goodcart = shoppingcarsmanager.SelectShoppingCarts(UserID);
            return View(goodcart);
        }
        [HttpPost]
        public ActionResult Carts(ShoppingCarts carts)
        {
            int goodid = Convert.ToInt32(Session["goodid"]);
            int userid = Convert.ToInt32(Session["UserID"]);
            int result = shoppingcarsmanager.ShopCartsCount(userid,goodid);
            if(result>0)
            {
                return Content("<script>alert('该商品已存在购物车');history.go(-1)</script>");
            }
            else
            { 
            carts.UserID = userid;
            carts.GoodsID = goodid;
            carts.UnitPrice =Convert.ToDecimal(Request.Form["price"]);
            carts.Number = Convert.ToInt32(Request.Form["Jm_Amount"]);
            carts.TotalAmount = carts.Number * carts.UnitPrice;
                shoppingcarsmanager.AddShopCarts(carts);
            //return RedirectToAction("Carts", "Goods", new { UserID=1});
            return Content("<script>alert('添加成功');history.go(-1)</script>");
            }
        }
        public ActionResult Remove(int goodid)
        {
            var removegood = shoppingcarsmanager.SelectOneShopCart(goodid);
            if (removegood != null)
            {
                shoppingcarsmanager.RemoveShopCarts(removegood);
            }
            return RedirectToAction("Carts", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) });
        }
        public ActionResult RemoveAll(int UserID)
        {
            var removeall = shoppingcarsmanager.SelectALlShopCart(Convert.ToInt32(Session["UserID"]));
            if (removeall != null)
            {
                shoppingcarsmanager.RemoveAllShopCart(removeall);
            }
            return RedirectToAction("Carts", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) });
        }
        public ActionResult Address()
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            var address = addressmanager.SelectAllAddress(userid);
            return View(address);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAddress(Address address)
        {
            try
            {
                if(ModelState.IsValid)
                { 
                     int userid = Convert.ToInt32(Session["UserID"]);
                     address.UserID = userid;
                     string Province = Request.Form["prov"];
                     string City = Request.Form["city"];
                     string DetailAddr = Request.Form["detailAddr"];
                     address.Province = Province;
                     address.City = City;
                     address.AddressDetail = DetailAddr;
                     address.IsDefault = Convert.ToInt32(Request.Form["xuanze"]);
                    addressmanager.AddAddress(address);
                     return Content("<script>alert('添加成功');history.go(-1)</script>");
            }
                else
                {
                    return Content("<script>alert('添加失败');history.go(-1)</script>");
                }

            }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
            
        }     
        public ActionResult RemoveAddress(int AddressID)
        {
            try {
            
                    int addressid = AddressID;
                    var address = addressmanager.SelectAddress(addressid);
                addressmanager.RemoveAddress(address);
                  return RedirectToAction("Carts", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) });
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                   throw dbEx;
            }
        }

        [HttpPost]
        public ActionResult JieSuan(Orders orders,OrderItems orderitems,Goods Goods)
        {
            try
            {

                    string[] goodid = Request.Params.GetValues("goodsid");
                    string[] unitprice = Request.Params.GetValues("danjia");
                    string[] amount = Request.Params.GetValues("geshu");
                    string[] CheckBOx = Request.Params.GetValues("chekbox2"); 
                    orders.Amount = Convert.ToInt32( Request.Form["selectTotal"]);
                    orders.OrderTime = DateTime.Now;
                    orders.UserID = Convert.ToInt32(Session["UserID"]);
                    ordersmanager.AddOrders(orders);
                    for (int i = 0; i < goodid.Length; i++)
                    {
                        if (CheckBOx[i]=="1")
                        {
                            int orderid = ordersmanager.SelectLastOrderid();
                            int GoodID= Convert.ToInt32(goodid[i]);
                            orderitems.OrderID = orderid;
                            orderitems.GoodsID = GoodID;
                            orderitems.UnitPrice = Convert.ToDecimal(unitprice[i]);
                            orderitems.Number = Convert.ToInt32(amount[i]);
                            orderitems.TotalAmount = orderitems.UnitPrice*orderitems.Number;
                            orderitemsmanager.AddOrderItems(orderitems);
                            goodsmanager.UpdateStockAndSalse(GoodID, orderitems.Number, orderitems.Number);

                            var removegood = shoppingcarsmanager.SelectOneShopCart(GoodID);
                            if (removegood != null)
                           {
                               shoppingcarsmanager.RemoveShopCarts(removegood);
                            }

                    }
                    }
                    return Content("<script>alert('结算成功');window.open('" + Url.Action("Carts", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) }) + "', '_self')</script>");
              
                //else
                //{
                //    return Content("<script>alert('结算失败');history.go(-1)</script>");
                //}
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                string error = dbEx.Message;
                throw dbEx;
            }
       }
        //public ActionResult EditAddress(int? addressid)
        //{
        //    //Address address = db.Address.Find(addressid);
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult EditAddress(Address address)
        //{
        //    if(ModelState.IsValid)
        //    { 
        //    address.AddressID =1;
        //    address.UserID = Convert.ToInt32(Session["UserID"]);
        //    address.Province = Request.Form["province4"];
        //    address.City = Request.Form["city4"];
        //    address.AddressDetail = Request.Form["DetailAdd"];
        //    address.IsDefault =int.Parse( Request.Form["xuanze1"]);
        //    db.Entry(address).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //        return Content("<script>alert('修改成功');history.go(-1)</script>");
        //        //return RedirectToAction("Carts", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) });   
        //    }
        //    return View(address);
        //}
        public ActionResult edit(int  addressid)
        {
            this.TempData["addressID"] = addressid;
            Address address = db.Address.Find(addressid);
            return View(address);
        }
        [HttpPost]
        public ActionResult edit(Address address)
        {
                address.AddressID = Convert.ToInt32(this.TempData["addressID"]);
                address.UserID = Convert.ToInt32(Session["UserID"]);
                address.Province = Request.Form["province4"];
                address.City = Request.Form["city4"];
                //address.AddressDetail = Request.Form["DetailAdd"];
                address.IsDefault = int.Parse(Request.Form["xuanze"]);
                db.Entry(address).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Content("<script>alert('修改成功');history.go(-1)</script>");
                //return RedirectToAction("Carts", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) });   
          
                 //return View(address);
        }
        public ActionResult OrderItem()
        {
            int userid= Convert.ToInt32(Session["UserID"]);
            var data = orderitemsmanager.SelectAllOrderItems(userid);
            return View(data);
        }
        public ActionResult RemoveOrderItem(int orderitemid)
        {
            int OrderItemID = orderitemid;
            var data = orderitemsmanager.Selectorderitems(OrderItemID);
            orderitemsmanager.Removeorderitems(data);
            return Content("<script>alert('删除成功');window.open('" + Url.Action("OrderItem", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) }) + "', '_self')</script>");
            //return RedirectToAction("RemoveOrderItem", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) });
        }
        public ActionResult RemoveAllOrderItems()
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            var removeAll = orderitemsmanager.SelectAllOrderItems(UserID);
            orderitemsmanager.RemoveAllOrderItems(removeAll);
            return Content("<script>alert('删除成功');window.open('" + Url.Action("OrderItem", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) }) + "', '_self')</script>");
            //return RedirectToAction("RemoveOrderItem", "Goods", new { UserID = Convert.ToInt32(Session["UserID"]) });
        }
        public ActionResult AdoptDetail(int goodid ,int activityid)
        {
            SucculentWeb.ViewModels.AdoptDetailViewModel AdoptDetail = new AdoptDetailViewModel();
            Session["AdoptGoodid"] = goodid;
            this.TempData["ActivityID"] = activityid;
            AdoptDetail.Gooddetail= goodsmanager.SelectGoodDetail(goodid);
            AdoptDetail.Shopdetail= shopmanager.SelectShopDetail(goodid);
            var AdoptDetailTuijian = goodsmanager.SelectDetailTuijianGoodid(goodid);
            Session["Detailshopid"] = AdoptDetailTuijian.ShopID;
            AdoptDetail.AdoptDetailTuijian = goodsmanager.SelectDetailTuijian8Goods(AdoptDetailTuijian.ShopID);
            ViewBag.CommentCount= goodscommentsmanager.GoodsCommentsCounts(goodid);
            ViewBag.total = (from p in db.Adopt where p.GoodsID == goodid select p.Total).FirstOrDefault();         
            return View(AdoptDetail);
        }
        [HttpPost]
        public ActionResult AdoptDetail(AdoptResult adoptresult)
        {
            if(ModelState.IsValid)
            {
                int userid= Convert.ToInt32(Session["UserID"]);
                int result = adoptresultmanager.getAdoptUser(userid);
                if(result>0)
                {
                    return Content("<script>alert('您已经领养，不能多次领养');history.go(-1)</script>");
                }
                else
                {
                 int activityid = Convert.ToInt32(this.TempData["ActivityID"]);
                 int adoptgoodid = Convert.ToInt32(Session["AdoptGoodid"]);
                 adoptresult.UserID = Convert.ToInt32(Session["UserID"]);
                 adoptresult.GoodsID = adoptgoodid;
                 adoptresult.ActivityID =  activityid;
                  adoptresult.AdoptTime = DateTime.Now;
                  adoptresult.Address = Request.Form["sheng"]+Request.Form["shi"] + Request.Form["xian"] + Request.Form["xiangxi"];
                  adoptresultmanager.AddAdoptResult(adoptresult);
                    adoptmanager.updateAdoptTotal(activityid);
                 return Content("<script>alert('领养成功');history.go(-1)</script>");
               }
            }
           
            else
            {
                return Content("<script>alert('领养失败');history.go(-1)</script>");
            }
            
        }
        public ActionResult Dianzan()
        {
            int goodid = Convert.ToInt32(Session["goodid"]);
            goodsmanager.GoodsZan(goodid);
            return Content("<script>alert('点赞成功');window.open('" + Url.Action("GoodsDetail", "Goods", new { goodid = Convert.ToInt32(Session["goodid"]) }) + "', '_self')</script>");
        }
    } 
}