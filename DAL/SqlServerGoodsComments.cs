using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
  public  class SqlServerGoodsComments:IGoodsComments
    {
        SucculentEntities db = new SucculentEntities();
      public  IEnumerable<GoodsComments> GetGoodsComments(int goodid)
        {
            var data= (from p in db.GoodsComments
                       where p.GoodsID == goodid
                       select p).OrderBy(p => p.PublishTime);
            return data;
        }
        public void InsertGoodsComments(GoodsComments goodscomments)
        {
            db.GoodsComments.Add(goodscomments);
            db.SaveChanges();
        }
        public int GoodsCommentCounts(int goodid)
        {
            var data= (from p in db.GoodsComments where p.GoodsID == goodid select p).Count();
            return data;
        }
    }
}
