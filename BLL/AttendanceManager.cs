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
    public class AttendanceManager
    {
        private static IAttendance iattendance = DataAccess.CreateAttendance();

        public static void InsertAttendance(Attendance attendance)
        {
            iattendance.InsertAttendance(attendance);
        }
        public static Attendance GetAttendanceByUserID(int UserID)
        {
            return iattendance.GetAttendanceByUserID(UserID);
        }
        public static bool IsAttendActivity(int UserID, int ActID)
        {
            return iattendance.IsAttendActivity(UserID,ActID);
        }
    }
}
