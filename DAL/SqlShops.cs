using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
   public  class SqlShops:IShops
    {
        SucculentEntities db = new SucculentEntities();
        public IEnumerable<Shops> GetTopShops()
        {
            var data = (from p in db.Shops select p).OrderByDescending(p=>p.SalesTotal).Take(6);
            
            return data;
        }

    }
}
