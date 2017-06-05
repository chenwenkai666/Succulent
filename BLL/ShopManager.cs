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
        public  IShops ishops = DataAccess.CreateShops();
        public  IEnumerable<Shops> SelectTopShops()
        {
            return ishops.GetTopShops();
        }
        public  IEnumerable<Shops> SelectAllShops()
        {
            return ishops.GetAllShops();
        }
        public  int SelectShopGoodsCount(int shopid)
        {
            return ishops.GetShopGoodsCount(shopid);
        }
        public  IEnumerable<Shops> SelectShopTopImage(int shopid)
        {
            return ishops.GetShopTopImage(shopid);
        }
        public  Shops SelectShopDetail(int goodid)
        {
            return ishops.GetShopDetail(goodid);
        }
        public  Shops SelectDetailTopImage(int shopid)
        {
            return ishops.GetDetailTopimage(shopid);
        }
        public  void CreateNewShops(Shops shop)
        {
           ishops.CreateNewShops(shop);
        }
        public  int SelectShopid(int userid)
        {
            return ishops.GetShopID(userid);
        }
        public  int SelectIsShoper(int userid)
        {
            return ishops.GetIsShoper(userid);
        }
        public Shops GetShopByUserID(int id)
        {
            return ishops.GetShopByUserID(id);
        }
    }
}
