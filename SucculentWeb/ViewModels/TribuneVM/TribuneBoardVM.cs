using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;

namespace SucculentWeb.ViewModels.TribuneVM
{
    public class TribuneBoardVM
    {
        public IEnumerable<Sections> Sections { get; set; }
        public IEnumerable<Posts> Posts { get; set; }
        public int PostsNumberAll { get; set; }
        public int PostsNumberToday { get; set; }
        public IEnumerable<Level> Boardlevels { get; set; }
    }
}