using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
   public  class SqlServerSucculent:ISucculent
    {
        SucculentEntities db = new SucculentEntities();
        public List<Succulent> SelectSucculent()
        {
            var succulent = (from s in db.Succulent             
                             select s).ToList();
            return succulent;

        }
        public List<Succulent> SelectSucculentByID()
        {
            var xiao = (from x in db.Succulent
                             where x.SucculentID == 18
                             select x).ToList();
            return xiao;

        }
        public void Create(Succulent succulent)
        {
            db.Succulent.Add(succulent);
            db.SaveChanges();
        }
    }
}
