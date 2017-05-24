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
    public class SqlServerActivity:IActivity
    {
        SucculentEntities db = new SucculentEntities();

        /// <summary>
        /// 查询所有活动分类
        /// </summary>
        /// <returns>IList</returns>
        public IList<ActivityCategory> GetActivityCategory()
        {
            return db.ActivityCategory.ToList();
        }

        /// <summary>
        /// 插入一个活动
        /// </summary>
        /// <param name="act">Activity实体</param>
        /// <returns>bool</returns>
        public bool InsertActivity(Activity act)
        {
            db.Activity.Add(act);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据ID查询活动
        /// </summary>
        /// <param name="id">活动ID</param>
        /// <returns>Activity</returns>
        public Activity GetActivity(int id)
        {
            return db.Activity.Where(act => act.ActivityID == id).FirstOrDefault();
        }

        /// <summary>
        /// 根据活动类别ID查询活动
        /// </summary>
        /// <param name="id">活动类别ID</param>
        /// <returns></returns>
        public IList<Activity> GetActivityByCategoryID(int id)
        {
            return db.Activity.Where(act => act.ActivityCategoryID == id).ToList();
        }
    }
}
