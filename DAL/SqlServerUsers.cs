using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using System.Data.Entity;

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

        public Users GetUserByName(string UserName)
        {
            Users users = (from u in db.Users
                           where u.UserName == UserName
                           select u).FirstOrDefault();
            return users;
        }

        public void UpdateUserInfo(Users users)
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public int AjaxLogin(string UserName, string Password)
        {
            var users = from u in db.Users
                        where u.UserName == UserName && u.Password == Password
                        select u;
            return users.Count();
        }

        public int GetUserLevel(string UserName)
        {
            try
            {
                Pots pot = db.Pots.Include("Users").Where(u => u.Users.UserName == UserName).FirstOrDefault();
                int level = pot.LevelID;
                return level;
            }
            catch
            {
                return 0;
            }
        }
        public Users GetUserByID(int UserID)
        {
            Users users = (from u in db.Users
                           where u.UserID == UserID
                           select u).FirstOrDefault();
            return users;
        }
    }
}
