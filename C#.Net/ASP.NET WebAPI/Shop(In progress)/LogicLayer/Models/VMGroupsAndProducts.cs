using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;

namespace ShopApi.Models
{
    //This is View Model for Products in Group
    public class GroupsAndProducts
    {
        public IEnumerable<string> groups { get; set; }
        public List<Products> products { get; set; }

        public Groups ChosenGroup { get; set; }

    }
}