using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
   public interface IOrderItems
    {
        IEnumerable<OrderItems> GetAllOrderItem(int userid);
        OrderItems GetOrderItem(int orderitemid);
        void RemoveOrderitem(OrderItems orderitems);
        void RemoveAllOrderitem(IEnumerable< OrderItems> orderitems);
        void AddOrderItems(OrderItems orderitem);
        int GoodCommentOrder(int userid,int goodid);
    }
}
