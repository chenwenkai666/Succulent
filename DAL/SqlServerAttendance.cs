using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
     public class SqlServerAttendance:IAttendance
    {
        SucculentEntities db = new SucculentEntities();
        public void InsertAttendance(Attendance attendance)
        {
            db.Attendance.Add(attendance);
            db.SaveChanges();
        }

        public Attendance GetAttendanceByUserID(int UserID)
        {
            return db.Attendance.Where(a => a.UserID == UserID).FirstOrDefault();
        }

        public bool IsAttendActivity(int UserID,int ActID)
        {
            var attend = from a in db.Attendance
                         where a.ActivityID == ActID && a.UserID == UserID
                         select a;
            if (attend.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IList<Attendance> SelectAllAttendanceByUserID(int UserID)
        {
            return db.Attendance.Where(a=>a.UserID==UserID).ToList();
        }
    }
}
