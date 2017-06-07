using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;
namespace SucculentWeb.ViewModels
{
    public class GoodsCommentsViewModel
    {
        public IEnumerable<GoodsComments> Comments { get; set; }
        public IEnumerable<ReplyGoods> ReplyGood { get; set; }
    }
}