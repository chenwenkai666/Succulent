using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
     public interface IUsers
    {
        void InsertUser(Users user);
        List<Users> SelectUser(string UserName);
        int Login(Users user);
        Users GetUserByName(string UserName);
        void UpdateUserInfo(Users users);
        int AjaxLogin(string UserName, string Password);
        int GetUserLevel(string UserName);
        Users GetUserByID(int UserID);
    }
}
