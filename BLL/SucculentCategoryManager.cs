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
        private ISucculentCategory isucculentcategory = DataAccess.CreateSucculentCategory();
        public List<SucculentCategory> Select()
        {
            return isucculentcategory.Select();
        }
        public SucculentCategory SelectByID(int id)
        {
            return isucculentcategory.SelectByID(id);
        }
    }
}
