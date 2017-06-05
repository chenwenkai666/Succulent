using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
    public class SqlServerShoppingCarts:IShoppingCarts
    {
        SucculentEntities db = new SucculentEntities();
        public IEnumerable<ShoppingCarts> GetShoppingCarts(int UserID)
        {
            var data = from p in db.ShoppingCarts where p.UserID == UserID select p;
            return data;
        }
        public void AddShoppingCarts(ShoppingCarts shopcart)
        {
            db.ShoppingCarts.Add(shopcart);
            db.SaveChanges();
        }
        public void RemoveShoppingCarts(ShoppingCarts shopcart)
        {
            db.ShoppingCarts.Remove(shopcart);
            db.SaveChanges();
        }
        public ShoppingCarts GetOneShopCart(int goodid)
        {
            var data= (from p in db.ShoppingCarts where p.GoodsID == goodid select p).FirstOrDefault();
            return data;
        }
        public IEnumerable<ShoppingCarts> GetAllShopCart(int UserID)
        {
            var data = from p in db.ShoppingCarts where p.UserID == UserID select p;
            return data;
        }
        public void RemoveAllShopCarts(IEnumerable< ShoppingCarts> shopcart)
        {
            db.ShoppingCarts.RemoveRange(shopcart);
            db.SaveChanges();
        }
        public int GetShopCartsCount(int userid, int goodid)
        {
            int data = (from p in db.ShoppingCarts where p.UserID == userid && p.GoodsID == goodid select p).Count();
            return data;
        }
    }
}
