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
   public  class OrdersManager
    {
        public  IOrders iorders = DataAccess.CreateOrders();
        public  void AddOrders(Orders orders)
        {
            iorders.AddOrders(orders);
        }
        public  int SelectLastOrderid()
        {
            return iorders.GetLastOrderid();
        }
    }
}
