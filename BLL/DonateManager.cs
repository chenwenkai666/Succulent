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
     public class DonateManager
    {
        public IDonate idonate = DataAccess.CreateDonate();
        public bool InsertDonate(Donate donate)
        {
            return idonate.InsertDonate(donate);
        }
        public Donate GetUserDonate(int UserID, int ActID)
        {
            return idonate.GetUserDonate(UserID,ActID);
        }
        public IList<Donate> GetDonateByActivityID(int ActID)
        {
            return idonate.GetDonateByActivityID(ActID);
        }
    }
}
