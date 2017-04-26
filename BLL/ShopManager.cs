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

    }
}
