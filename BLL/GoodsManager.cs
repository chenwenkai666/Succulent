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
        public  IGoods igoods = DataAccess.CreateGoods();
        public  IEnumerable<Goods> SelectTopSucculent()
        {
            return  igoods.GetTopSucculent();
        }
        public IEnumerable<Goods> SelectTopHuapen()
        {
            return igoods.GetTopHuapen();
        }
        public  IEnumerable<Goods> SelectTopZhiliao()
        {
            return igoods.GetTopZhiliao();
        }
        public  IEnumerable<Goods> SelectTopGongju()
        {
            return igoods.GetTopGongju();
        }
        public IEnumerable<Goods> SelectTopPenzai()
        {
            return igoods.GetTopPenzai();
        }
        public  IEnumerable<Goods> SelectTopDingzhi()
        {
            return igoods.GetTopDingzhi();
        }
        public  IEnumerable<Goods> SelectHotSearch()
        {
            return igoods.GetTopHotSearch();
        }
        public  IEnumerable<Goods>SelectTopTen()
        {
            return igoods.GetTopNewTen();
        }
        public  IEnumerable<Goods>SelectTopHot()
        {
            return igoods.GetTopHotGoods();
        }
        public  IEnumerable<Goods> Select9to14()
        {
            return igoods.Get9to14();
        }
        public IEnumerable<Goods> SelectYFMShopGoods()
        {
            return igoods.GetYFMShopGoods();
        }
        public  IEnumerable<Goods> SelectTuijian()
        {
            return igoods.GetTuijian();
        }
        public  IEnumerable<Goods> SelectSearchMall()
        {
            return igoods.GetSearchMall();

        }
        public  IEnumerable<Goods> SelectShopPrice(int Shopid)
        {
            return igoods.GetShopPrice(Shopid);
        }
        public  IEnumerable<Goods> SelectShopLike(int Shopid)
        {
            return igoods.GetShopLike(Shopid);
        }
        public  IEnumerable<Goods> SelectShopTime(int Shopid)
        {
            return igoods.GetShopTime(Shopid);
        }
        public  IEnumerable<Goods> SelectShopDuorouZhiwu(int Shopid)
        {
            return igoods.GetShopDuorouZhiwu(Shopid);
        }
        public  IEnumerable<Goods> SelectShopHuaqi(int Shopid)
        {
            return igoods.GetShopHuaqi(Shopid);
        }
        public  IEnumerable<Goods> SelectShopZhiliao(int Shopid)
        {
            return igoods.GetShopZhiliao(Shopid);
        }
        public  IEnumerable<Goods> SelectShopZuhe(int Shopid)
        {
            return igoods.GetShopZuhe(Shopid);
        }
        public  IEnumerable<Goods> SelectShopGongju(int Shopid)
        {
            return igoods.GetShopGongju(Shopid);
        }
        public  IEnumerable<Goods> SelectMallZhiwu()
        {
            return igoods.GetMallZhiwu();
        }
        public  IEnumerable<Goods> SelectMallGongju()
        {
            return igoods.GetMallGongju();
        }
        public  IEnumerable<Goods> SelectMallHuaqi()
        {
            return igoods.GetMallHuaqi();
        }
        public  IEnumerable<Goods> SelectMallZhiliao()
        {
            return igoods.GetMallZhiliao();
        }
        public  IEnumerable<Goods> SelectMallZuhe()
        {
            return igoods.GetMallZuhe();
        }
        public  IEnumerable<Goods> SelectShopMall4Goods(int Shopid)
        {
            return igoods.GetShopMall4Goods(Shopid);
        }
        public  Goods SelectGoodDetail(int Goodid)
        {
            return igoods.GetGoodDetail(Goodid);
        }
        public  Goods SelectDetailTuijianGoodid(int goodid)
        {
            return igoods.GetDetailTuijianGoodid(goodid);
        }
        public  IEnumerable<Goods> SelectDetailTuijian8Goods(int shopid)
        {
            return igoods.GetDetailTuijian8Goods(shopid);
        }
        public  IEnumerable<Goods> SelectAllGoods()
        {
            return igoods.GetAllGoods();
        }
        public  IEnumerable<Goods> SelectSearchGoods(string searchstring)
        {
            return igoods.GetSearchGoods(searchstring);
        }
        public  void CreateGoods(Goods goods)
        {
             igoods.CreateGoods(goods);
        }
        public void GoodsZan(int goodid)
        {
            igoods.GoodsZan(goodid);
        }
        public void UpdateStockAndSalse(int goodid,int stock,int salse)
        {
            igoods.updateStockAndSalse(goodid,stock,salse);
        }
    }
}
