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
   public class GoodsCommentsManager
    {
        public  IGoodsComments igoodscomments = DataAccess.CreateGoodsComments();
        public  IEnumerable<GoodsComments> SelectGoodsComment(int goodid)
        {
            return igoodscomments.GetGoodsComments(goodid);
        }
        public  void InsertGoodsComment(GoodsComments goodscomment)
        {
            igoodscomments.InsertGoodsComments(goodscomment);
        }
        public  int GoodsCommentsCounts(int goodid)
        {
            return  igoodscomments.GoodsCommentCounts(goodid);
        }
    }
}
