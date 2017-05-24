using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IDonate
    {
        bool InsertDonate(Donate donate);
        Donate GetUserDonate(int UserID, int ActID);
        IList<Donate> GetDonateByActivityID(int ActID);
    }
}
