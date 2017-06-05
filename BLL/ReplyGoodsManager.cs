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
   public class ReplyGoodsManager
    {
        public IReplyGoods ireplygoods = DataAccess.CreateReplyGoods();
        public  void InsertReplyGoods(ReplyGoods replygoods)
        {
            ireplygoods.InsertReplyGoods(replygoods);
        }
    }
}
