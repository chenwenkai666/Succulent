using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
     public class SqlServerAdoptResult:IAdoptResult
    {
        SucculentEntities db = new SucculentEntities();

        public IList<AdoptResult> GetAdoptResultByActID(int ActID)
        {
            return db.AdoptResult.Where(ar => ar.ActivityID == ActID).ToList() ;
        }
    }
}
