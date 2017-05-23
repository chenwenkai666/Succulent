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
     public class AdoptManager
    {
        private static IAdopt iadopt = DataAccess.CreateAdopt();
        public static IList<Adopt> GetAdoptListByActID(int ActID)
        {
            return iadopt.GetAdoptListByActID(ActID);
        }
        public static bool InsertAdopt(Adopt adopt)
        {
            return iadopt.InsertAdopt(adopt);
        }
    }
}
