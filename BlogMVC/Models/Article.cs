using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Models
{
    public class Article
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Title")]
        public string ArticleTitle { get; set; }
        [Required]
        //[MinLength(500, ErrorMessage = "Yazınız en az {1} karakterden oluşmalıdır")]
        [Display(Name = "Content")]
        [AllowHtml]
        public string ArticleContent { get; set; }
        [Display(Name ="Posted on")]
        public DateTime? PostedDate { get; set; }
        public string ArticlePhoto { get; set; }

        public string Author { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual Category Category { get; set; }
    }
}