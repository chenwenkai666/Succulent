using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
     public class SqlServerAdopt:IAdopt
    {
        SucculentEntities db = new SucculentEntities();

        public IList<Adopt> GetAdoptListByActID(int ActID)
        {
            return db.Adopt.Include("Goods").Where(a=>a.ActivityID==ActID).ToList();
        }

        public bool InsertAdopt(Adopt adopt)
        {
            db.Adopt.Add(adopt);
            return db.SaveChanges() > 0;
        }
    }
}
