using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DALFactory;
using Model;


namespace BLL
{
     public class AdoptResultManager
    {
        private static IAdoptResult iadoptresult = DataAccess.CreateAdoptResult();

        public static IList<AdoptResult> GetAdoptResultByActID(int ActID)
        {
            return iadoptresult.GetAdoptResultByActID(ActID);
        }

    }
}
