using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SucculentWeb.ViewModels
{
    public class UserCenterVM
    {
        public IEnumerable<Posts> post { get; set; }
        public IEnumerable<Attendance> attendance { get; set; }
        public IEnumerable<Collection> collection { get; set; }
        public IEnumerable<PostComments> postcomments { get; set; }
        public IEnumerable<OrderItems> orderitems { get; set; }
    }
}