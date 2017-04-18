using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
    public class SqlServerUsers:IUsers
    {
        SucculentEntities db = new SucculentEntities();
        public void InsertUser(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public List<Users> SelectUser(string UserName)
        {
            var users = (from u in db.Users
                        where u.UserName == UserName
                        select u).ToList();
            return users;

        }

        public int Login(Users user)
        {
            var users = from u in db.Users
                        where u.UserName == user.UserName && u.Password==user.Password
                        select u;
            int result = users.Count();
            return result;
        }
    }
}
