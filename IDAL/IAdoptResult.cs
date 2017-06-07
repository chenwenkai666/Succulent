using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
   public interface IAdoptResult
    {
        void AddAdoptResult(AdoptResult adoptresult);
        IList<AdoptResult> GetAdoptResultByActID(int ActID);
        int getAdoptUser(int userid);
    }
}
