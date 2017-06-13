using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IDAL;
using Model;
using System.Data.Entity;

namespace DAL
{
   public class SqlServerSucculent:ISucculent
    {
        SucculentEntities db = new SucculentEntities();
        public List<Succulent> SelectSucculent()
        {
            var succulent = (from s in db.Succulent             
                             select s).OrderByDescending(c=>c.CollectedTotal).ToList();
            return succulent;

        }
        public List<Succulent> SelectSucculentByID(int id)
        {
            var xiao = (from x in db.Succulent.AsNoTracking()
                             where x.SucculentID == id
                             select x).ToList();
            return xiao;

        }

        public List<Succulent> SelectSucculentBySucculentid(int id)
        {
            var succulent = db.Succulent.Where(c => c.SucculentID == id).ToList();
            return succulent;
        }
       public List<Succulent> SelectSucculentByCatogaryid(int categoryid)
        {
            var succulent = db.Succulent.AsNoTracking().Where(c => c.CategoryID == categoryid).Take(9).ToList();
            return succulent;
        }
        public List<Succulent> SelectXinagsiSucculent(int categoryid,int id)
        {
            var succulent = db.Succulent.Where(c => c.CategoryID == categoryid&&c.SucculentID!= id).OrderByDescending(r => r.CollectedTotal).Take(9).ToList();
            return succulent;
        }
        public List<Succulent> SelectRoomSucculent()
        {
            var room = db.Succulent.OrderByDescending(r => r.CollectedTotal).Take(9).ToList();
            return room;
        }
        public void Create(Succulent succulent)
        {
            db.Succulent.Add(succulent);
            db.SaveChanges();
        }

        public Succulent SelectName(string name)
        {
            var succulent = db.Succulent.Where(c => c.SucculentName == name).FirstOrDefault();
            return succulent;
        }
      
        public void UpdateAdd(Succulent succulent)
        {
           
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Entry(succulent).State = EntityState.Modified;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;            

        }
        public Succulent SelectByID(int id)
        {
            var succulent = db.Succulent.Where(c => c.SucculentID == id).FirstOrDefault();
            return succulent;

        }

        public IEnumerable<Succulent> SelectBySearchName(string SearchName)
        {
            var succulent = from s in db.Succulent.Where(o => o.SucculentName.Contains(SearchName)).ToList() select s;
            return succulent;
        }
    }
}
