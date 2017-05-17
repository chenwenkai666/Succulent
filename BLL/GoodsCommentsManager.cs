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
        public static IGoodsComments igoodscomments = DataAccess.CreateGoodsComments();
        public static IEnumerable<GoodsComments> SelectGoodsComment(int goodid)
        {
            return igoodscomments.GetGoodsComments(goodid);
        }
        public static void InsertGoodsComment(GoodsComments goodscomment)
        {
            igoodscomments.InsertGoodsComments(goodscomment);
        }
    }
}
