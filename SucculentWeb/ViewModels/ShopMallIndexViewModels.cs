using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;
namespace SucculentWeb.ViewModels
{
    public class ShopMallIndexViewModels
    {
        public IEnumerable<Goods>Succulent{get;set;}
        public IEnumerable<Goods> Huapen { get; set; }
        public IEnumerable<Goods> Zhiliao { get; set; }
        public IEnumerable<Goods> Gongju { get; set; }
        public IEnumerable<Goods> Penzai { get; set; }
        public IEnumerable<Goods> Dingzhi { get; set; }
        public IEnumerable<Goods> HotSearch { get; set; }
        public IEnumerable<Goods> NewGoods { get; set; }
        public IEnumerable<Goods> HotGoods { get; set; }
        public IEnumerable<Goods> hotGoods {get;set;}
        public IEnumerable<Shops> Shops { get; set; }
        public IEnumerable<Goods> MallClass { get; set; }
        public IEnumerable<Shops> ShopMallShops { get; set; }
        public int ShopGoodsCount { get; set; }
        public IEnumerable<Goods> ShopMall4Goods { get; set; }
    }
}