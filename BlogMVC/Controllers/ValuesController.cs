using BlogMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogMVC.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            Person person = new Person
            {
                Id = 1,
                Name = "Bilgeadam"
            };
            return Json(person);
        }

        public IHttpActionResult Post(Person person)
        {
            var _person = person;
            return Ok(person);
        }
    }
}
