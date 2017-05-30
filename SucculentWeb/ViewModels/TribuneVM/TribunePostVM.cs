using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;

namespace SucculentWeb.ViewModels.TribuneVM
{
    public class TribunePostVM
    {
        public IEnumerable<Posts> Posts { get; set; }
        public IEnumerable<PostComments> PostComment { get; set; }
        public IEnumerable<Users> UserInfo { get; set; }
    }
}