using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DALFactory;
using Model;

namespace BLL
{
    public class ActivityManager
    {
        public IActivity iactivity = DataAccess.CreateActivity();

        public IList<ActivityCategory> GetActivityCategory()
        {
            return iactivity.GetActivityCategory();
        }
        public bool InsertActivity(Activity act)
        {
            return iactivity.InsertActivity(act);
        }
        public Activity GetActivity(int id)
        {
            return iactivity.GetActivity(id);
        }
        public IList<Activity> GetActivityByCategoryID(int id)
        {
            return iactivity.GetActivityByCategoryID(id);
        }
        public IList<Activity> GetActivityByKeywords(string keywords)
        {
            return iactivity.GetActivityByKeywords(keywords);
        }
    }
}
