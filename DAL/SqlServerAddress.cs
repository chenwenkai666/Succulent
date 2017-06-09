using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
   public class SqlServerAddress:IAddress
    {
        SucculentEntities db = new SucculentEntities();
        public IEnumerable<Address> GetAllAddress(int userid)
        {
            var data= from p in db.Address join b in db.Users on p.UserID equals b.UserID where p.UserID == userid select p;
            return data;
        }
        public void AddAddress(Address address)
        {
            db.Address.Add(address);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public Address GetAddress(int addressid)
        {
            var data = (from p in db.Address where p.AddressID == addressid select p).FirstOrDefault();
            return data;
        }
        public void RemoveAddress(Address address)
        {
            db.Address.Remove(address);
            db.SaveChanges();
        }
    }
}
