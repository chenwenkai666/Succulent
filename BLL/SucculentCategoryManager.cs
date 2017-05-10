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
   public class SucculentCategoryManager
    {
        private static ISucculentCategory isucculentcategory = DataAccess.CreateSucculentCategory();
        public static List<SucculentCategory> Select()
        {
            return isucculentcategory.Select();
        }
    }
}
