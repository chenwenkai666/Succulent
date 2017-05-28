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
        private static IActivity iactivity = DataAccess.CreateActivity();

        public static IList<ActivityCategory> GetActivityCategory()
        {
            return iactivity.GetActivityCategory();
        }
        public static bool InsertActivity(Activity act)
        {
            return iactivity.InsertActivity(act);
        }
        public static Activity GetActivity(int id)
        {
            return iactivity.GetActivity(id);
        }
        public static IList<Activity> GetActivityByCategoryID(int id)
        {
            return iactivity.GetActivityByCategoryID(id);
        }
        public static IList<Activity> GetActivityByKeywords(string keywords)
        {
            return iactivity.GetActivityByKeywords(keywords);
        }
    }
}
