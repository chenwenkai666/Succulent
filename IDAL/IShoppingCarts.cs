using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
   public interface IShoppingCarts
    {
        IEnumerable<ShoppingCarts> GetShoppingCarts(int UserID);
        void AddShoppingCarts(ShoppingCarts shopcart);
        void RemoveShoppingCarts(ShoppingCarts shopcart);
        ShoppingCarts GetOneShopCart(int goodid);
        IEnumerable< ShoppingCarts> GetAllShopCart(int UserID);
        void RemoveAllShopCarts(IEnumerable< ShoppingCarts> shopcart);
        int GetShopCartsCount(int userid,int goodid);
    }
}
