using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DALFactory;
using IDAL;
using Model;

namespace BLL
{
    public class LevelManager
    {
        public ILevel ilevel = DataAccess.CreateLevel();
        public IList<Level> GetAllLevels()
        {
            return ilevel.GetAllLevels();
        }
    }
}
