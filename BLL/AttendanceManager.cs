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
        public IAttendance iattendance = DataAccess.CreateAttendance();

        public void InsertAttendance(Attendance attendance)
        {
            iattendance.InsertAttendance(attendance);
        }
        public Attendance GetAttendanceByUserID(int UserID)
        {
            return iattendance.GetAttendanceByUserID(UserID);
        }
        public bool IsAttendActivity(int UserID, int ActID)
        {
            return iattendance.IsAttendActivity(UserID,ActID);
        }
        public IList<Attendance> SelectAllAttendanceByUserID(int UserID)
        {
            return iattendance.SelectAllAttendanceByUserID(UserID);
        }
    }
}
