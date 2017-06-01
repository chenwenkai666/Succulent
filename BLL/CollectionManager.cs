using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DALFactory;
using IDAL;

namespace BLL
{
   public class CollectionManager
    {
        private static ICollection icollection = DataAccess.CreateCollection();
        public static void Create(Collection collection)
        {
            icollection.Create(collection);
        }
        public static Collection SelectbySucculentId(int succulentid)
        {
            return icollection.SelectbySucculentId(succulentid);
        }
    }
}
