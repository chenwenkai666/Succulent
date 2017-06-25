using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
     public class SqlServerCharitableResult:ICharitableResult
    {
        SucculentEntities db = new SucculentEntities();
        public  CharitableResult GetCharitableResultByActID(int ActID)
        {
            return db.CharitableResult.Where(c=>c.ActivityID==ActID).FirstOrDefault();
        }
    }
}
