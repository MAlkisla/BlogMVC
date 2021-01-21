using BlogMVC.Models;
using BlogMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //var user = db.Users.First();
            //db.Articles.Find(1).User = user;
            //db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}