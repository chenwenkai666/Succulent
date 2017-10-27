using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DALFactory;
using IDAL;


namespace BLL
{
    public class LookManager
    {
        private ILook ilook = DataAccess.CreateLook();
        public void NewCreate(Look look)
        {
            ilook.NewCreate(look);
        }
        public IEnumerable<Look> NewSelectbySucculentId(int succulentid)
        {
            return ilook.NewSelectbySucculentId(succulentid);
        }
        public IEnumerable<Look> NewSelectByUserID(int UserID)
        {
            return ilook.NewSelectByUserID(UserID);
        }
        public Look NewSelectSucculent(int UserID)
        {
            return ilook.NewSelectSucculent(UserID);
        }

        public IEnumerable<Look> NewSelectByCategoryID(int categoryid)
        {
            return ilook.NewSelectByCategoryID(categoryid);
        }
        public void NewUpdateAdd(Look look)
        {
            ilook.NewUpdateAdd(look);
        }
    }
}
