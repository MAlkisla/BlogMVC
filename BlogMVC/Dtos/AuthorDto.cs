using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Dtos
{
    public class AuthorDto
    {
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorInfo { get; set; }
        public string AuthorPhoto{ get; set; }
        public HttpPostedFileBase Photo{ get; set; }
    }
}