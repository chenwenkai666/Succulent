using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;
using PagedList;
using PagedList.Mvc;

namespace SucculentWeb.ViewModels.TribuneVM
{
    public class TribunePostVM
    {
        public Posts Posts { get; set; }
        public IPagedList<PostComments> PostComment { get; set; }
        public IEnumerable<Users> UserInfo { get; set; }
        public ReplyPost RlyPosts { get; set; }
    }
}