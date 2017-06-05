using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
  public   class SqlServerOrders:IOrders
    {
        SucculentEntities db = new SucculentEntities();
        public void AddOrders(Orders orders)
        {
            db.Orders.Add(orders);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public int GetLastOrderid()
        {
            var data = db.Orders.AsEnumerable().Last().OrderID;
            return data;
        }
    }
}
