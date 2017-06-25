using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class CharitableResultVM
    {
        public CharitableResult charitableresult { get; set; }
        public IEnumerable<Donate> donate { get; set; }
    }
}