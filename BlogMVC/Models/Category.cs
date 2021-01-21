using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name ="Category")]
        public string CategoryName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}