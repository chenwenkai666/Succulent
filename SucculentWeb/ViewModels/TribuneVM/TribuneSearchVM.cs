using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;

namespace SucculentWeb.ViewModels.TribuneVM
{
    public class TribuneSearchVM
    {
        public IEnumerable<Users> infouser { get; set; }
        public IEnumerable<Posts> infopost { get; set; }
        public IEnumerable<PostComments> infopostcom { get; set; }
        public IEnumerable<ReplyPost> infopostrly { get; set; }
    }
}