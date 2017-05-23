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
        private static IDonate idonate = DataAccess.CreateDonate();
        public static bool InsertDonate(Donate donate)
        {
            return idonate.InsertDonate(donate);
        }
        public static Donate GetUserDonate(int UserID, int ActID)
        {
            return idonate.GetUserDonate(UserID,ActID);
        }
        public static IList<Donate> GetDonateByActivityID(int ActID)
        {
            return idonate.GetDonateByActivityID(ActID);
        }
    }
}
