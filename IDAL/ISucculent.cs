using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
   public interface ISucculent
    {
        List<Succulent> SelectSucculent();
        List<Succulent> SelectSucculentByID();
        void Create(Succulent succulent);
    }
}
