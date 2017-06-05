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
        public Collection SelectbySucculentId(int succulentid)
        {           
            Collection collection= (from c in db.Collection
                           where c.SucculentID == succulentid
                           select c).FirstOrDefault();
            return collection;
        }
    }
}
