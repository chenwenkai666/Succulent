using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class AdoptSucculentVM
    {
        public Activity Activity { set; get; }
        public IEnumerable<Adopt> AdoptList { set; get; }
        public IEnumerable<AdoptResult> AdoptResult { set; get; }
    }
}