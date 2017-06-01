using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IActivity
    {
        IList<ActivityCategory> GetActivityCategory();
        bool InsertActivity(Activity act);
        Activity GetActivity(int id);
        IList<Activity> GetActivityByCategoryID(int id);
        IList<Activity> GetActivityByKeywords(string keywords);
    }
}
