using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }

        public virtual Article article { get; set; }

        public virtual ApplicationUser applicationUser { get; set; }
    }
}