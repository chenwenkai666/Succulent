using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;
namespace SucculentWeb.ViewModels
{
    public class GoodDetailViewModel
    {
        public IEnumerable<Goods> GoodDetail { get; set; }
    }
}