using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
   public interface IShops
    {
        IEnumerable<Shops> GetTopShops();
        IEnumerable<Shops> GetAllShops();
        int GetShopGoodsCount(int ShopID);
        IEnumerable<Shops> GetShopTopImage(int shopid);
        Shops GetShopDetail(int goodid);
        Shops GetDetailTopimage(int shopid);
        void CreateNewShops(Shops shop);
        int GetShopID(int userid);
        int GetIsShoper(int userid);
        Shops GetShopByUserID(int UserID);
    }
}
