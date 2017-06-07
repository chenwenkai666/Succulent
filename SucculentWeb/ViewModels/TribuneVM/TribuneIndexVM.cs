using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;

namespace SucculentWeb.ViewModels.TribuneVM
{
    public class TribuneIndexVM
    {
        public IEnumerable<Posts> SelectIndexPost01 { get; set; }
        public IEnumerable<Posts> SelectIndexPost02 { get; set; }
        public IEnumerable<PostComments> SelectIndexPost03 { get; set; }
        public IEnumerable<Sections> Sections03 { get; set; }
        public IEnumerable<Sections> Sections06 { get; set; }
        public int PostsNumberAll { get; set; }
        public int PostsNumberToday { get; set; }
        public int GetAllPostNum { get; set; }
        public int GetTodayPostNum { get; set; }
        public int GetYesterdayPostNum { get; set; }
    }
}