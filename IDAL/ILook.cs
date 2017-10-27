using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface ILook
    {
        void NewCreate(Look look);
        IEnumerable<Look> NewSelectbySucculentId(int succulentid);
        Look NewSelectSucculent(int UserID);
        IEnumerable<Look> NewSelectByUserID(int UserID);
        IEnumerable<Look> NewSelectByCategoryID(int categoryid);
        void NewUpdateAdd(Look look);

    }
}

