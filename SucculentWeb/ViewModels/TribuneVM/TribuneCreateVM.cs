using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SucculentWeb.ViewModels;
using Model;

namespace SucculentWeb.ViewModels.TribuneVM
{
    public class TribuneCreateVM
    {
        public Posts Posts { get; set; }
        public IEnumerable<Sections> Sections03 { get; set; }
        public IEnumerable<Sections> Sections06 { get; set; }
        public IEnumerable<Sections> Sections33 { get; set; }
    }
}