using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
  public  class SqlServerGoods:IGoods
    {
        SucculentEntities db = new SucculentEntities();
        public  IEnumerable<Goods> GetTopSucculent()
        {

            
            var data = from p in db.Goods select p;
            data = data.Where(o=>o.GoodsName.Contains("多肉植物")).OrderByDescending(p=>p.LikeIt).Take(11);
            return data;
        }
        public IEnumerable<Goods> GetTopHuapen()
        {
            var data = from p in db.Goods select p;
            data = data.Where(o=>o.GoodsName.Contains("花盆")).OrderByDescending(p=>p.LikeIt).Take(6);
            return data;
        }
        public IEnumerable<Goods> GetTopZhiliao()
        {
            var data = from p in db.Goods select p;
            data = data.Where(o => o.GoodsName.Contains("土")).OrderByDescending(p => p.LikeIt).Take(6);
            return data;
        }
        public IEnumerable<Goods>GetTopGongju()
        {
            var data = from p in db.Goods select p;
            data = data.Where(o => o.GoodsName.Contains("工具")).OrderByDescending(p => p.LikeIt).Take(6);
            return data;
        }
        public IEnumerable<Goods> GetTopPenzai()
        {
            var data = from p in db.Goods select p;
            data = data.Where(o => o.GoodsName.Contains("盆栽")).OrderByDescending(p => p.LikeIt).Take(6);
            return data;
        }
        public IEnumerable<Goods> GetTopDingzhi()
        {
            var data = (from p in db.Goods where p.Flag == 1 select p).OrderByDescending(p=>p.LikeIt).Take(6);       
            return data;
        }
        public IEnumerable<Goods> GetTopHotSearch()
        {
            var data = (from p in db.Goods select p).OrderByDescending(p=>p.LikeIt).Take(11);
            
            return data;
        }
        public IEnumerable<Goods> GetTopNewTen()
        {
           
                var data = (from p in db.Goods .AsNoTracking() orderby p.Time select p).Take(10);
                return data;
            
        }
        public IEnumerable<Goods> GetTopHotGoods()
        {
            var data = (from p in db.Goods select p).OrderByDescending(p => p.LikeIt).Take(8);
            return data;
        }
        public IEnumerable<Goods> Get9to14()
        {
            var data = (from p in db.Goods select p).OrderByDescending(p => p.LikeIt).Skip(8).Take(6);
            return data;
        }
        public IEnumerable<Goods> GetYFMShopGoods()
        {
            var data = (from p in db.Goods where p.ShopID == 2 select p).Take(12);
            return data;
        }
        public IEnumerable<Goods>GetTuijian()
        {
            var data = (from p in db.Goods select p).OrderByDescending(p => p.LikeIt).Take(4);
            return data;
        }
        public IEnumerable<Goods> GetSearchMall()
        {
            var data = from p in db.Goods select p;
            data = data.Where(o => o.GoodsName.Contains("searchString")).OrderByDescending(p => p.LikeIt).Take(6);
            return data;
        }
        public IEnumerable<Goods> GetShopPrice(int Shopid)
        {
            var data= from p in db.Goods
                      where p.ShopID == Shopid
                      orderby p.Price
                      select p;
            return data;
        }
        public IEnumerable<Goods> GetShopLike(int Shopid)
        {
            var data = from p in db.Goods
                       where p.ShopID == Shopid
                       orderby p.LikeIt
                       select p;
            return data;
        }
        public IEnumerable<Goods> GetShopTime(int Shopid)
        {
            var data = from p in db.Goods where p.ShopID == Shopid orderby p.Time select p;
            return data;
        }
        public IEnumerable<Goods> GetShopDuorouZhiwu(int Shopid)
        {
            //var data = from p in db.Goods where p.GoodsName.Contains("植物") orderby p.Price select p;
            var data = from p in db.Goods  where p.GoodsName.Contains("多肉植物")&&p.ShopID==Shopid orderby p.Price select p;
            //data = data.Where(o => o.GoodsName.Contains("多肉植物")).OrderByDescending(p => p.Price);
            return data;
        }
         public  IEnumerable<Goods> GetShopGongju(int Shopid)
        {
            var data= from p in db.Goods where p.GoodsName.Contains("工具") && p.ShopID == Shopid orderby p.Price select p;
            return data;
        }
         public IEnumerable<Goods> GetShopZhiliao(int Shopid)
        {
            var data = from p in db.Goods where p.GoodsName.Contains("土") && p.ShopID == Shopid orderby p.Price select p;
            return data;
        }
          public IEnumerable<Goods> GetShopHuaqi(int Shopid)
        {
            var data = from p in db.Goods where p.GoodsName.Contains("花盆") && p.ShopID == Shopid orderby p.Price select p;
            return data;
        }
         public IEnumerable<Goods> GetShopZuhe(int Shopid)
        {
            var data = from p in db.Goods where p.GoodsName.Contains("盆栽") && p.ShopID == Shopid orderby p.Price select p;
            return data;
        }
        public IEnumerable<Goods> GetMallZhiwu()
        {
            var data = from p in db.Goods where p.GoodsName.Contains("多肉植物")  orderby p.Price select p;
            return data;
        }
        public IEnumerable<Goods> GetMallGongju()
        {
            var data = from p in db.Goods where p.GoodsName.Contains("工具") orderby p.Price select p;
            return data;
        }
        public IEnumerable<Goods> GetMallZhiliao()
        {
            var data = from p in db.Goods where p.GoodsName.Contains("土") orderby p.Price select p;
            return data;
        }
        public IEnumerable<Goods> GetMallHuaqi()
        {
            var data = from p in db.Goods where p.GoodsName.Contains("花盆") orderby p.Price select p;
            return data;
        }
        public IEnumerable<Goods> GetMallZuhe()
        {
            var data = from p in db.Goods where p.GoodsName.Contains("盆栽") orderby p.Price select p;
            return data;
        }
       public IEnumerable<Goods> GetShopMall4Goods(int Shopid)
        {
            var data = (from p in db.Goods where p.ShopID == Shopid select p).OrderByDescending(p => p.LikeIt).Take(4);
            return data;
        }
        public Goods GetGoodDetail(int goodid)
        {
            var data = db.Goods.AsNoTracking().Where(b => b.GoodsID == goodid).FirstOrDefault();
            return data;
        }
        public Goods GetDetailTuijianGoodid(int goodid)
        {
            var data= (from p in db.Goods
                       join b in db.Shops
                       on p.ShopID equals b.ShopID
                       where p.GoodsID == goodid
                       select p).FirstOrDefault();
            return data;
        }
        public IEnumerable<Goods> GetDetailTuijian8Goods(int shopid)
        {
            var data= (from p in db.Goods where p.ShopID ==shopid select p).Take(8);
            return data;
        }
        public IEnumerable<Goods> GetAllGoods()
        {
            var data = from p in db.Goods.OrderBy(p => p.Price) select p;
            return data;
        }
        public IEnumerable<Goods> GetSearchGoods(string searchstring)
        {
            var data= db.Goods.Where(s => (s.GoodsName.Contains(searchstring))).OrderBy(p=>p.Price);
            return data;
        }
        public void CreateGoods(Goods goods)
        {
            db.Goods.Add(goods);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
           
        }
        public void GoodsZan(int goodid)
        {
            Goods good = (from p in db.Goods where p.GoodsID == goodid select p).FirstOrDefault();
            good.LikeIt = good.LikeIt + 1;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void updateStockAndSalse(int goodid, int stock, int salse)
        {
            Goods Good = (from p in db.Goods where p.GoodsID == goodid select p).FirstOrDefault();
            Good.Sales = Good.Sales + salse;
            Good.Stock = Good.Stock - stock;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
