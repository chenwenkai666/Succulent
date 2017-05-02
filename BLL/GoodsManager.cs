using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using DALFactory;
using IDAL;
namespace BLL
{
  public  class GoodsManager
    {
        public static IGoods igoods = DataAccess.CreateGoods();
        public static IEnumerable<Goods> SelectTopSucculent()
        {
            return  igoods.GetTopSucculent();
        }
        public static IEnumerable<Goods> SelectTopHuapen()
        {
            return igoods.GetTopHuapen();
        }
        public static IEnumerable<Goods> SelectTopZhiliao()
        {
            return igoods.GetTopZhiliao();
        }
        public static IEnumerable<Goods> SelectTopGongju()
        {
            return igoods.GetTopGongju();
        }
        public static IEnumerable<Goods> SelectTopPenzai()
        {
            return igoods.GetTopPenzai();
        }
        public static IEnumerable<Goods> SelectTopDingzhi()
        {
            return igoods.GetTopDingzhi();
        }
        public static IEnumerable<Goods> SelectHotSearch()
        {
            return igoods.GetTopHotSearch();
        }
        public static IEnumerable<Goods>SelectTopTen()
        {
            return igoods.GetTopNewTen();
        }
        public static IEnumerable<Goods>SelectTopHot()
        {
            return igoods.GetTopHotGoods();
        }
        public static IEnumerable<Goods> Select9to14()
        {
            return igoods.Get9to14();
        }
    }
}
