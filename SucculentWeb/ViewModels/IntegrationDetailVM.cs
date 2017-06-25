using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class IntegrationDetailVM
    {
        public Goods Gooddetail { get; set; }
        public Shops Shopdetail { get; set; }
        public IEnumerable<Goods> IntegrationDetailTuijian { get; set; }
    }
}