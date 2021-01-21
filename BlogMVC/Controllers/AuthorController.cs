using BlogMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    public class AuthorController : BaseController
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        public ActionResult AuthorInfo(string username)
        {
            if (username != null)
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == username);
                return View(user);
            }
            return HttpNotFound();
        }
    }
}