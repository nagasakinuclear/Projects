using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopApi.Models
{
    //This is View Model for Product and Groups
    public class GroupsAndProduct
    {
        public IEnumerable<string> groups { get; set; }
        public Products product { get; set; }

        public Groups productGroup { get; set; }
    }
}