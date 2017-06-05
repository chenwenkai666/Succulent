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
    public class OrderItemsManager
    {
        public  IOrderItems iorderitems = DataAccess.CreateOrderItems();
        public  IEnumerable<OrderItems> SelectAllOrderItems(int userid)
        {
            return iorderitems.GetAllOrderItem(userid);
        }
        public  OrderItems Selectorderitems(int orderitemid)
        {
            return iorderitems.GetOrderItem(orderitemid);
        }
        public  void Removeorderitems(OrderItems orderitems)
        {
            iorderitems.RemoveOrderitem(orderitems);
        }
        public  void RemoveAllOrderItems(IEnumerable<OrderItems> orderitems)
        {
            iorderitems.RemoveAllOrderitem(orderitems);
        }
        public  void AddOrderItems(OrderItems orderitems)
        {
            iorderitems.AddOrderItems(orderitems);
        }
        public  int GoodCommentOrder(int userid,int goodid)
        {
            return iorderitems.GoodCommentOrder(userid,goodid);
        }
    }
}
