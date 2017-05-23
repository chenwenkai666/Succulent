using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using DALFactory;
using IDAL;
namespace BLL
{
   public class ShopManager
    {
        public static IShops ishops = DataAccess.CreateShops();
        public static IEnumerable<Shops> SelectTopShops()
        {
            return ishops.GetTopShops();
        }
        public static IEnumerable<Shops> SelectAllShops()
        {
            return ishops.GetAllShops();
        }
        public static int SelectShopGoodsCount(int shopid)
        {
            return ishops.GetShopGoodsCount(shopid);
        }
        public static IEnumerable<Shops> SelectShopTopImage(int shopid)
        {
            return ishops.GetShopTopImage(shopid);
        }
        public static Shops SelectShopDetail(int goodid)
        {
            return ishops.GetShopDetail(goodid);
        }
        public static Shops SelectDetailTopImage(int shopid)
        {
            return ishops.GetDetailTopimage(shopid);
        }
        public static Shops GetShopByUserID(int UserID)
        {
            return ishops.GetShopByUserID(UserID);
        }
    }
}
