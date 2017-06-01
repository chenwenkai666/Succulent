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
        private static IEntries ientries = DataAccess.CreateEntries();
        public static bool InsertEntries(Entries entry)
        {
            return ientries.InsertEntries(entry);
        }
        public static bool IsPublishEntry(int UserID, int ActID)
        {
            return ientries.IsPublishEntry(UserID,ActID);
        }
        public static IList<Entries> GetAllEntriesByActID(int ActID)
        {
            return ientries.GetAllEntriesByActID(ActID);
        }
        public static bool AddUpvoteNum(int UserID, int ActID)
        {
            return ientries.AddUpvoteNum(UserID, ActID);
        }
    }
}
