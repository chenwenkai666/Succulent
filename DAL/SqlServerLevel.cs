using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
    public class SqlServerLevel:ILevel
    {
        SucculentEntities db = new SucculentEntities();
        public IList<Level> GetAllLevels()
        {
            return db.Level.ToList();
        }
    }
}
