using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
    public interface IAddress
    {
        IEnumerable<Address> GetAllAddress(int userid);
        void AddAddress(Address address);
        Address GetAddress(int addressid);
        void RemoveAddress(Address address);
    }
}
