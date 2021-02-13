using BlogMVC.Dtos;
using BlogMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BlogMVC.Controllers
{
    public class AuthorApiController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IHttpActionResult GetAuthors()
        {

            var liste = db.Users.Select(x => new AuthorDto
            {
                AuthorId = x.Id,
                AuthorInfo = x.AuthorInfo,
                AuthorName = x.AuthorName,
                AuthorPhoto = x.AuthorPhoto,
            }).ToList();

            return Json(liste);
        }

        [HttpPut]
        public IHttpActionResult PutAuthors(AuthorDto authorDto, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var user = db.Users.Find(id);
            user.AuthorInfo = authorDto.AuthorInfo;
            user.AuthorPhoto = authorDto.AuthorPhoto;
            user.AuthorName = authorDto.AuthorName;
            return Ok();
        }
    }
}
