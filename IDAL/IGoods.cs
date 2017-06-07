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
        IEnumerable<Goods> GetYFMShopGoods();
        IEnumerable<Goods> GetTuijian();
        IEnumerable<Goods> GetSearchMall();
        IEnumerable<Goods> GetShopPrice(int Shopid);
        IEnumerable<Goods> GetShopLike(int Shopid);
        IEnumerable<Goods> GetShopTime(int Shopid);
        IEnumerable<Goods> GetShopDuorouZhiwu(int Shopid);
        IEnumerable<Goods> GetShopGongju(int Shopid);
        IEnumerable<Goods> GetShopZhiliao(int Shopid);
        IEnumerable<Goods> GetShopHuaqi(int Shopid);
        IEnumerable<Goods> GetShopZuhe(int Shopid);
        IEnumerable<Goods> GetMallZhiwu();
        IEnumerable<Goods> GetMallGongju();
        IEnumerable<Goods> GetMallZhiliao();
        IEnumerable<Goods> GetMallHuaqi();
        IEnumerable<Goods> GetMallZuhe();
        IEnumerable<Goods> GetShopMall4Goods(int Shopid);
        Goods GetGoodDetail(int goodid);
        Goods GetDetailTuijianGoodid(int goodid);
        IEnumerable<Goods> GetDetailTuijian8Goods(int shopid);
        IEnumerable<Goods> GetAllGoods();
        IEnumerable<Goods> GetSearchGoods(string searchstring);
        void CreateGoods(Goods goods);
        void GoodsZan(int goodid);
        void updateStockAndSalse(int goodid,int stock,int salse);
    }
}
