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
        public IAdopt iadopt = DataAccess.CreateAdopt();
        public IList<Adopt> GetAdoptListByActID(int ActID)
        {
            return iadopt.GetAdoptListByActID(ActID);
        }
        public bool InsertAdopt(Adopt adopt)
        {
            return iadopt.InsertAdopt(adopt);
        }
        public void updateAdoptTotal(int activityid)
        {
            iadopt.updateAdoptTotal(activityid);
        }
    }
}
