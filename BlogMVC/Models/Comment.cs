using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Comment
    {
       
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public int ArticleId { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Yorum en fazla 500 karakterden oluşimalıdır.")]
        [Display(Name = "Comment")]
        public string CommentText { get; set; }
        [Display(Name = "Posted on")]
        public DateTime? PostedDate { get; set; }

        public string CommentAuthor { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Article Article { get; set; }
    }
}