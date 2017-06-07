using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
     public interface IAdopt
    {
        IList<Adopt> GetAdoptListByActID(int ActID);
        bool InsertAdopt(Adopt adopt);
        void updateAdoptTotal(int activityid);
    }
}
