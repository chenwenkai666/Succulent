using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
   public  interface IGoods
    {
        IEnumerable<Goods> GetTopSucculent();
        IEnumerable<Goods> GetTopHuapen();
        IEnumerable<Goods> GetTopZhiliao();
        IEnumerable<Goods> GetTopGongju();
        IEnumerable<Goods> GetTopPenzai();
        IEnumerable<Goods> GetTopDingzhi();
        IEnumerable<Goods> GetTopHotSearch();
        IEnumerable<Goods> GetTopNewTen();
        IEnumerable<Goods> GetTopHotGoods();
        IEnumerable<Goods> Get9to14();

    }
}
