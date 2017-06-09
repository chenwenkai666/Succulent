using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
   public class SqlServerCollection:ICollection
    {
        SucculentEntities db = new SucculentEntities();
        public void Create(Collection collection)
        {
            db.Collection.Add(collection);
            db.SaveChanges();
        }
        public IEnumerable<Collection> SelectbySucculentId(int succulentid)
        {           
            var collection= (from c in db.Collection
                           where c.SucculentID == succulentid
                           select c).ToList();
            return collection;
        }
        public Collection SelectSucculent(int UserID)
        {
            Collection collection = (from c in db.Collection where c.UserID == UserID select c).FirstOrDefault();
            return collection;
        }
        
        public IEnumerable<Collection> SelectByUserID(int UserID)
        {
            var collection = (from c in db.Collection join s in db.Succulent on c.SucculentID equals s.SucculentID where c.UserID == UserID select c).ToList();
            return collection;
        }
    }
}
