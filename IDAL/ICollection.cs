using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
   public interface ICollection
    {
        void Create(Collection collection);
        Collection SelectbySucculentId(int succulentid);
        IEnumerable<Collection> SelectByUserID(int UserID);
    }
}
