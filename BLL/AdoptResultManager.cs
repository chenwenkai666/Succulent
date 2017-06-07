using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using DALFactory;
using IDAL;
namespace BLL
{
   public class AdoptResultManager
    {
        public  IAdoptResult iadoptresult = DataAccess.CreateAdoptResult();
        public  void AddAdoptResult(AdoptResult adoptresult)
        {
            iadoptresult.AddAdoptResult(adoptresult);
        }
        public IList<AdoptResult> GetAdoptResultByActID(int ActID)
        {
            return iadoptresult.GetAdoptResultByActID(ActID);
        }
        public int getAdoptUser(int userid)
        {
            return iadoptresult.getAdoptUser(userid);
        }
    }
}
