using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
  public  interface IGoodsComments
    {
        IEnumerable<GoodsComments> GetGoodsComments(int goodid);
          void InsertGoodsComments(GoodsComments goodscomments);
        int GoodsCommentCounts(int goodid);
    }
}
