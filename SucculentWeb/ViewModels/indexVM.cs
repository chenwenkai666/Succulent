using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class indexVM
    {
        public IEnumerable<Succulent> succulent
        {
            get; set;
        }
        public IEnumerable<Shops> shops
        {
            get; set;
        }
        public IEnumerable<Goods> goods
        {
            get; set;
        }
    }
}