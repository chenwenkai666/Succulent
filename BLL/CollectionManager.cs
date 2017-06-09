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
        private ICollection icollection = DataAccess.CreateCollection();
        public  void Create(Collection collection)
        {
            icollection.Create(collection);
        }
        public IEnumerable<Collection> SelectbySucculentId(int succulentid)
        {
            return icollection.SelectbySucculentId(succulentid);
        }
        public IEnumerable<Collection> SelectByUserID(int UserID)
        {
            return icollection.SelectByUserID(UserID);
        }
        public Collection SelectSucculent(int UserID)
        {
            return icollection.SelectSucculent(UserID);
        }
    }
}
