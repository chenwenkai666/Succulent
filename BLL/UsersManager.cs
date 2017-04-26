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
        public static Users GetUser(string UserName)
        {
            return iusers.GetUser(UserName);
        }
        public static void UpdateUserInfo(Users users)
        {
            iusers.UpdateUserInfo(users);
        }
    }
}
