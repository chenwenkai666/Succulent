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
    public class EntriesManager
    {
        public IEntries ientries = DataAccess.CreateEntries();
        public bool InsertEntries(Entries entry)
        {
            return ientries.InsertEntries(entry);
        }
        public bool IsPublishEntry(int UserID, int ActID)
        {
            return ientries.IsPublishEntry(UserID,ActID);
        }
        public IList<Entries> GetAllEntriesByActID(int ActID)
        {
            return ientries.GetAllEntriesByActID(ActID);
        }
        public bool AddUpvoteNum(int UserID, int ActID)
        {
            return ientries.AddUpvoteNum(UserID, ActID);
        }
    }
}
