using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class AdoptListAddVM
    {
        public Activity Activity { set; get; }
        public Shops Shops { set; get; }
        public IEnumerable<Goods> Goods { set; get; }
    }
}