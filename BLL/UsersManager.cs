using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using DALFactory;
using IDAL;

namespace BLL
{
    public class UsersManager
    {
        private IUsers iusers = DataAccess.CreateUsers();
        public  void InsertUser(Users user)
        {
            iusers.InsertUser(user);
        }
        public  List<Users> SelectUser(string UserName)
        {
            return iusers.SelectUser(UserName);
        }
        public int Login(Users user)
        {
            return iusers.Login(user);
        }
        public Users GetUserByName(string UserName)
        {
            return iusers.GetUserByName(UserName);
        }
        public  void UpdateUserInfo(Users users)
        {
            iusers.UpdateUserInfo(users);
        }
        public int AjaxLogin(string UserName, string Password)
        {
            return iusers.AjaxLogin(UserName, Password);
        }
        public int GetUserLevel(string UserName)
        {
            return iusers.GetUserLevel(UserName);
        }
        public  Users GetUserByID(int UserID)
        {
            return iusers.GetUserByID(UserID);
        }
    }
}
