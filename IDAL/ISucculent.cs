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
        List<Succulent> SelectSucculentByID(int id);
        List<Succulent> SelectSucculentBySucculentid(int id);
        List<Succulent> SelectSucculentByCatogaryid(int categoryid);
        List<Succulent> SelectXinagsiSucculent(int categoryid, int id);
        List<Succulent> SelectRoomSucculent();
        void Create(Succulent succulent);
        void UpdateAdd(Succulent succulent);
        Succulent SelectByID(int id);
        Succulent SelectName(string name);
        IEnumerable<Succulent> SelectBySearchName(string SearchName);
    }
}
