using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
  public  class SqlGoods:IGoods
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
            var data = (from p in db.Goods select p).Take(10);
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
    }
}
