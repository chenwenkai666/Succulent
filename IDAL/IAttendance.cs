using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IAttendance
    {
        void InsertAttendance(Attendance attendance);
        Attendance GetAttendanceByUserID(int UserID);
        bool IsAttendActivity(int UserID, int ActID);
        IList<Attendance> SelectAllAttendanceByUserID(int UserID);
    }
}
