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
        private static IUsers iusers = DataAccess.CreateUsers();
        public  static void InsertUser(Users user)
        {
            iusers.InsertUser(user);
        }
        public static List<Users> SelectUser(string UserName)
        {
            return iusers.SelectUser(UserName);
        }
        public static int Login(Users user)
        {
            return iusers.Login(user);
        }
        public static Users GetUserByName(string UserName)
        {
            return iusers.GetUserByName(UserName);
        }
        public static void UpdateUserInfo(Users users)
        {
            iusers.UpdateUserInfo(users);
        }
        public static int AjaxLogin(string UserName, string Password)
        {
            return iusers.AjaxLogin(UserName, Password);
        }
        public static int GetUserLevel(string UserName)
        {
            return iusers.GetUserLevel(UserName);
        }
        public static Users GetUserByID(int UserID)
        {
            return iusers.GetUserByID(UserID);
        }
    }
}
