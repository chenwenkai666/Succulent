using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
    public class SqlServerDonate:IDonate
    {
        SucculentEntities db = new SucculentEntities();

        public bool InsertDonate(Donate donate)
        {
            db.Donate.Add(donate);
            return db.SaveChanges() > 0;
        }
        public Donate GetUserDonate(int UserID,int ActID)
        {
            //Donate donate = (from d in db.Donate
            //                where d.ActivityID == ActID && d.UserID == UserID
            //                select d).FirstOrDefault();
            return db.Donate.Include("Users").Where(d => d.ActivityID == ActID).Where(d => d.UserID == UserID).FirstOrDefault();
        }
        public IList<Donate> GetDonateByActivityID(int ActID)
        {
            return db.Donate.Where(d => d.ActivityID == ActID).ToList();
        }
    }
}
