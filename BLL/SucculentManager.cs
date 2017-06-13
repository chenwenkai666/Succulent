using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using DALFactory;
using IDAL;


namespace BLL
{
   public class SucculentManager
    {
        private ISucculent isucculent = DataAccess.CreateSucculent();
        public List<Succulent> SelectSucculent()
        {
            return isucculent.SelectSucculent();
        }
        public List<Succulent> SelectSucculentByID(int id)
        {
            return isucculent.SelectSucculentByID(id);
        }
        public List<Succulent> SelectSucculentBySucculentid(int id)
        {
            return isucculent.SelectSucculentBySucculentid(id);
        }
        public  List<Succulent> SelectSucculentByCatogaryid(int categoryid)
        {
            return isucculent.SelectSucculentByCatogaryid(categoryid);
        }
        public List<Succulent> SelectXinagsiSucculent(int categoryid, int id)
        {
            return isucculent.SelectXinagsiSucculent(categoryid, id);
        }
        public  List<Succulent> SelectRoomSucculent()
        {
            return isucculent.SelectRoomSucculent();
        }
        public void Create(Succulent succulent)
        {
            isucculent.Create(succulent);
        }
        public Succulent SelectName(string name)
        {
           return isucculent.SelectName(name);
        }
        public void UpdateAdd(Succulent succulent)
        {
            isucculent.UpdateAdd(succulent);
        }
        public Succulent  SelectByID(int id)
        {
            return isucculent.SelectByID(id);

        }
        public IEnumerable<Succulent> SelectBySearchName(string SearchName)
        {
            return isucculent.SelectBySearchName(SearchName);
        }
    }
}
