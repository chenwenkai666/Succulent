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
    public class SqlServerLook : ILook
    {
        SucculentEntities db = new SucculentEntities();
        public void NewCreate(Look look)
        {
            db.Look.Add(look);
            db.SaveChanges();
        }
        public IEnumerable<Look> NewSelectbySucculentId(int succulentid)
        {
            var look = (from c in db.Look
                        where c.SucculentID == succulentid
                        select c).ToList();
            return look;
        }
        public Look NewSelectSucculent(int UserID)
        {
            Look look = (from c in db.Look where c.UserID == UserID select c).FirstOrDefault();
            return look;
        }

        public IEnumerable<Look> NewSelectByUserID(int UserID)
        {
            var look = (from c in db.Look join s in db.Succulent on c.SucculentID equals s.SucculentID where c.UserID == UserID select c).Take(9).ToList();
            return look;
        }
        public IEnumerable<Look> NewSelectByCategoryID(int categoryid)
        {
            var look = db.Look.Where(l => l.SucculentCategoryID == categoryid).Take(9).ToList();
            return look;
        }
        public void NewUpdateAdd(Look look)
        {
            db.Entry(look).State = EntityState.Modified;
           // db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
           // db.Configuration.ValidateOnSaveEnabled = true;

        }
    }
}
