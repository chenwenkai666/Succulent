using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class ActivityIndexVM
    {
        // public IEnumerable<Activity> PhotographActivity
        // {
        //     get; set;
        // }
        // public IEnumerable<Activity> DIYActivity
        // {
        //     get; set;
        // }
        // public IEnumerable<Activity> AdoptActivity
        // {
        //     get; set;
        // }
        //public  IEnumerable<Activity> CharitableActivity
        // {
        //     get; set;
        // }

        public PagedList.IPagedList<Activity> PhotographActivity
        {
            get; set;
        }
        public PagedList.IPagedList<Activity> DIYActivity
        {
            get; set;
        }
        public PagedList.IPagedList<Activity> AdoptActivity
        {
            get; set;
        }
        public PagedList.IPagedList<Activity> CharitableActivity
        {
            get; set;
        }
    }
}