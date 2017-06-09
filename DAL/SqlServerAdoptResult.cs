using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
   public class SqlServerAdoptResult:IAdoptResult
    {
        SucculentEntities db = new SucculentEntities();
       public void AddAdoptResult(AdoptResult adoptresult)
        {
            db.AdoptResult.Add(adoptresult);
            db.SaveChanges();
        }
        public IList<AdoptResult> GetAdoptResultByActID(int ActID)
        {
            return db.AdoptResult.Where(ar => ar.ActivityID == ActID).ToList();
        }
        public int getAdoptUser(int userid)
        {
            var result = (from p in db.AdoptResult where p.UserID == userid select p).Count();
            return result;
        }
    }
}
