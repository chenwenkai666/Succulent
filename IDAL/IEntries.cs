using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IEntries
    {
        bool InsertEntries(Entries entry);
        bool IsPublishEntry(int UserID, int ActID);
        IList<Entries> GetAllEntriesByActID(int ActID);
        bool AddUpvoteNum(int UserID, int ActID);
    }
}
