using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Areas.Admin.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int QuantityC { get; set; }
    }
}