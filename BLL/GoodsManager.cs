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
        public static IEnumerable<Goods> SelectYFMShopGoods()
        {
            return igoods.GetYFMShopGoods();
        }
        public static IEnumerable<Goods> SelectTuijian()
        {
            return igoods.GetTuijian();
        }
        public static IEnumerable<Goods> SelectSearchMall()
        {
            return igoods.GetSearchMall();

        }
        public static IEnumerable<Goods> SelectShopPrice(int Shopid)
        {
            return igoods.GetShopPrice(Shopid);
        }
        public static IEnumerable<Goods> SelectShopLike(int Shopid)
        {
            return igoods.GetShopLike(Shopid);
        }
        public static IEnumerable<Goods> SelectShopTime(int Shopid)
        {
            return igoods.GetShopTime(Shopid);
        }
        public static IEnumerable<Goods> SelectShopDuorouZhiwu(int Shopid)
        {
            return igoods.GetShopDuorouZhiwu(Shopid);
        }
        public static IEnumerable<Goods> SelectShopHuaqi(int Shopid)
        {
            return igoods.GetShopHuaqi(Shopid);
        }
        public static IEnumerable<Goods> SelectShopZhiliao(int Shopid)
        {
            return igoods.GetShopZhiliao(Shopid);
        }
        public static IEnumerable<Goods> SelectShopZuhe(int Shopid)
        {
            return igoods.GetShopZuhe(Shopid);
        }
        public static IEnumerable<Goods> SelectShopGongju(int Shopid)
        {
            return igoods.GetShopGongju(Shopid);
        }
        public static IEnumerable<Goods> SelectMallZhiwu()
        {
            return igoods.GetMallZhiwu();
        }
        public static IEnumerable<Goods> SelectMallGongju()
        {
            return igoods.GetMallGongju();
        }
        public static IEnumerable<Goods> SelectMallHuaqi()
        {
            return igoods.GetMallHuaqi();
        }
        public static IEnumerable<Goods> SelectMallZhiliao()
        {
            return igoods.GetMallZhiliao();
        }
        public static IEnumerable<Goods> SelectMallZuhe()
        {
            return igoods.GetMallZuhe();
        }
        public static IEnumerable<Goods> SelectShopMall4Goods(int Shopid)
        {
            return igoods.GetShopMall4Goods(Shopid);
        }
        public static Goods SelectGoodDetail(int Goodid)
        {
            return igoods.GetGoodDetail(Goodid);
        }
        public static Goods SelectDetailTuijianGoodid(int goodid)
        {
            return igoods.GetDetailTuijianGoodid(goodid);
        }
        public static IEnumerable<Goods> SelectDetailTuijian8Goods(int shopid)
        {
            return igoods.GetDetailTuijian8Goods(shopid);
        }
        public static IEnumerable<Goods> SelectAllGoods()
        {
            return igoods.GetAllGoods();
        }
        public static IEnumerable<Goods> SelectSearchGoods(string searchstring)
        {
            return igoods.GetSearchGoods(searchstring);
        }
    }
}
