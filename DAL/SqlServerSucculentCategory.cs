using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using System.Data.Entity;

namespace DAL
{
  public class SqlServerSucculentCategory:ISucculentCategory
    {
        SucculentEntities db = new SucculentEntities();
        public List<SucculentCategory> Select()
        {
            var category = (from c in db.SucculentCategory
                            select c).ToList();
            return category;

        }
        public SucculentCategory SelectByID(int id)
        {
            var category = db.SucculentCategory.Where(c => c.SucculentCategoryID == id).FirstOrDefault();
            return category;
        }
    }
}
