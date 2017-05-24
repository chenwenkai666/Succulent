using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class SucculentIndexViewModels
    {
        //public IEnumerable<Succulent> succulent
        //{
        //    get; set;
        //}
        //public IEnumerable<SucculentCategory> succulentcategory
        //{
        //    get; set;
        //}
        public IEnumerable<Succulent> succulent_Details
        {
            get; set;
        }
        public IEnumerable<Succulent> Like
        {
            get; set;
        }
        public IEnumerable<Succulent> Room
        {
            get; set;
        }
    }
   
}