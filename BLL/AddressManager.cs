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
   public class AddressManager
    {
        public  IAddress iaddress = DataAccess.CreateAddress();
        public  IEnumerable<Address> SelectAllAddress(int userid)
        {
            return iaddress.GetAllAddress(userid);
        }
        public  void AddAddress(Address address)
        {
            iaddress.AddAddress(address);
        }
        public  Address SelectAddress(int addressid)
        {
            return iaddress.GetAddress(addressid);
        }
        public  void RemoveAddress(Address address)
        {
            iaddress.RemoveAddress(address);
        }
    }
}
