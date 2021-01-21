using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}