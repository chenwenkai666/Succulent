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
    public class SqlServerEntries:IEntries
    {
        SucculentEntities db = new SucculentEntities();
        public bool InsertEntries(Entries entry)
        {
            db.Entries.Add(entry);
            return db.SaveChanges() > 0;
        }
        public bool IsPublishEntry(int UserID,int ActID)
        {
            var entry = from e in db.Entries
                        where e.ActivityID == ActID && e.UserID == UserID
                        select e;
            return entry.Count() > 0;
        }
        public IList<Entries> GetAllEntriesByActID(int ActID)
        {
            return db.Entries.Where(e => e.ActivityID == ActID).ToList();
        }
        public bool AddUpvoteNum(int UserID, int ActID)
        {
            Entries entry = db.Entries.Where(e => e.UserID == UserID).Where(e => e.ActivityID == ActID).FirstOrDefault();
            entry.UpvoteNum += 1;
            db.Entry(entry).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

    }
}
