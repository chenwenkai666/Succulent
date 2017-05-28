using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class SearchResultVM
    {
        public IEnumerable<Succulent> BaiKe { get; set; }
        public IEnumerable<Activity> Activity { get; set; }
        public IEnumerable<Posts> Posts { get; set; }
        public IEnumerable<Goods> Goods { get; set; }
    }
}