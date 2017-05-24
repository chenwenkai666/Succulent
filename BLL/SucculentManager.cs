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
        private static ISucculent isucculent = DataAccess.CreateSucculent();
        public static List<Succulent> SelectSucculent()
        {
            return isucculent.SelectSucculent();
        }
        public static List<Succulent> SelectSucculentByID(int id)
        {
            return isucculent.SelectSucculentByID(id);
        }
        public static List<Succulent> SelectSucculentBySucculentid(int id)
        {
            return isucculent.SelectSucculentBySucculentid(id);
        }
        public static List<Succulent> SelectSucculentByCatogaryid(int categoryid)
        {
            return isucculent.SelectSucculentByCatogaryid(categoryid);
        }
        public static List<Succulent> SelectRoomSucculent()
        {
            return isucculent.SelectRoomSucculent();
        }
        public static void Create(Succulent succulent)
        {
            isucculent.Create(succulent);
        }
        public static void UpdateAdd(Succulent succulent)
        {
            isucculent.UpdateAdd(succulent);
        }
        public static Succulent  SelectByID(int id)
        {
            return isucculent.SelectByID(id);

        }
    }
}
