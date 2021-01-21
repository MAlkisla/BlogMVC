using BlogMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.ViewModels
{
    public class Archive
    {
        public DateTime Time {get; set; }
        public int QuantityArticle {get; set; }
    }
    public class HomeBlogViewModel
    {
        public ICollection<Article> Articles { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Archive> Archives { get; set; }
    }
}