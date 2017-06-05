using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using DALFactory;
using IDAL;
namespace BLL
{
    public class ShoppingCartsManager
    {
        public  IShoppingCarts ishoppingcarts = DataAccess.CreateShoppingCarts();
        public  IEnumerable<ShoppingCarts> SelectShoppingCarts(int UserID)
        {
            return ishoppingcarts.GetShoppingCarts(UserID);
        }
        public  void AddShopCarts(ShoppingCarts shopcart)
        {
            ishoppingcarts.AddShoppingCarts(shopcart);
        }
        public  void RemoveShopCarts(ShoppingCarts shopcart)
        {
            ishoppingcarts.RemoveShoppingCarts(shopcart);
        }
        public  ShoppingCarts SelectOneShopCart(int goodid)
        {
            return ishoppingcarts.GetOneShopCart(goodid);
        }
        public  IEnumerable< ShoppingCarts> SelectALlShopCart(int UserID)
        {
            return ishoppingcarts.GetAllShopCart(UserID);
        }
        public  void RemoveAllShopCart(IEnumerable< ShoppingCarts> shopcart)
        {
            ishoppingcarts.RemoveAllShopCarts(shopcart);
        }
        public  int ShopCartsCount(int userid,int goodid)
        {
            return ishoppingcarts.GetShopCartsCount(userid,goodid);
        }
    }
}
