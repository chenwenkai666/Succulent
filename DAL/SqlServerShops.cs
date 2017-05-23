using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
   public  class SqlServerShops:IShops
    {
        SucculentEntities db = new SucculentEntities();
        public IEnumerable<Shops> GetTopShops()
        {
            var data = (from p in db.Shops select p).OrderByDescending(p=>p.SalesTotal).Take(6);
            
            return data;
        }
        public IEnumerable<Shops> GetAllShops()
        {
            var data = (from p in db.Shops
                       join b in db.Users
                       on p.UserID equals b.UserID
                       select p).OrderBy(p=>p.UserID);
            return data;
        }
       public int GetShopGoodsCount(int ShopID)
        {
            var data=from p in db.Goods
                     join b in db.Shops
                     on p.ShopID equals b.ShopID
                     where p.ShopID==ShopID select p;
            return data.Count();
        }
        public IEnumerable<Shops> GetShopTopImage(int shopid)
        {
            var data = from p in db.Shops where p.ShopID == shopid select p ;
            return  data;
        }
        public Shops GetShopDetail(int goodid)
        {
            var data= (from p in db.Shops
                       join b in db.Goods
                       on p.ShopID equals b.ShopID
                       where b.GoodsID == goodid
                       select p).FirstOrDefault();
            return data;
        }
        public Shops GetDetailTopimage(int shopid)
        {
            var data = (from p in db.Shops where p.ShopID == shopid select p).FirstOrDefault();
            return data;
        }
        public Shops GetShopByUserID(int UserID)
        {
            return db.Shops.Where(p => p.UserID == UserID).FirstOrDefault();
        }
    }
}
