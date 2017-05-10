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
        public static List<Succulent> SelectSucculentByID()
        {
            return isucculent.SelectSucculentByID();
        }
        public static void Create(Succulent succulent)
        {
            isucculent.Create(succulent);
        }
    }
}
