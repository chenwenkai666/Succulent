using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IPots
    {
        bool InsertPots(Pots pots);
        Pots GetPotsByUserID(int UserID);
        bool UpdateExperience(int UserID, int Exp);
        bool PotsSign(int UserID);
    }
}
