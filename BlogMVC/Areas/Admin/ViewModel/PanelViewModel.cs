using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Areas.Admin.ViewModel
{
    public class PanelViewModel
    {
        public int QuantitiyArticles { get; set; }
        public int QuantitiyCategories { get; set; }
        public int QuantitiyComments { get; set; }
        public int QuantitiyTags { get; set; }
    }
}