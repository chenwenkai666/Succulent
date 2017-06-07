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
    public class PotsManager
    {
        public IPots ipots = DataAccess.CreatePots();

        public  bool InsertPots(Pots pots)
        {
            return ipots.InsertPots(pots);
        }
        public  Pots GetPotsByUserID(int UserID)
        {
            return ipots.GetPotsByUserID(UserID);
        }
        public  bool UpdateExperience(int UserID, int Exp)
        {
            return ipots.UpdateExperience(UserID,Exp);
        }
        public  bool PotsSign(int UserID)
        {
            return ipots.PotsSign(UserID);
        }
    }
}
