using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
   public class SqlServerOrderItems:IOrderItems
    {
        SucculentEntities db = new SucculentEntities();
        public IEnumerable<OrderItems> GetAllOrderItem(int userid)
        {
            var data = from p in db.OrderItems where p.Orders.UserID == userid  select p;
            data = data.OrderByDescending(p => p.Orders.OrderTime);
            return data;
        }
        public OrderItems GetOrderItem(int orderitemid)
        {
            var data = (from p in db.OrderItems where p.OrderItemsID == orderitemid select p).FirstOrDefault();
            return data;
        }
        public void RemoveOrderitem(OrderItems orderitems)
        {
            db.OrderItems.Remove(orderitems);
            db.SaveChanges();
        }
        public void RemoveAllOrderitem(IEnumerable<OrderItems> orderitems)
        {
            db.OrderItems.RemoveRange(orderitems);
            db.SaveChanges();
        }
        public void AddOrderItems(OrderItems orderitem)
        {
            db.OrderItems.Add(orderitem);
            db.SaveChanges();
        }
        public int GoodCommentOrder(int userid, int goodid)
        {
            var data= (from p in db.OrderItems where p.Orders.UserID == userid && p.GoodsID == goodid select p).Count();
            return data;
        }
    }
}
