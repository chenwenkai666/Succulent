using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
   public class SqlServerReplyGoods:IReplyGoods
    {
        SucculentEntities db = new SucculentEntities();
        public void InsertReplyGoods(ReplyGoods replygoods)
        {
            db.ReplyGoods.Add(replygoods);
            db.SaveChanges();
        }
    }
}
