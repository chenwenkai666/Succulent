using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DALFactory;
using IDAL;

namespace BLL
{
     public class CharitableResultManager
    {
        public ICharitableResult icharitableresult = DataAccess.CreateCharitableResult();
        public  CharitableResult GetCharitableResultByActID(int ActID)
        {
            return icharitableresult.GetCharitableResultByActID(ActID);
        }
    }
}
