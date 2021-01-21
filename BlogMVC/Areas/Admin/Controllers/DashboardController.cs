using BlogMVC.Areas.Admin.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var pvm = new PanelViewModel()
            {
                QuantitiyArticles = db.Articles.Where(x => x.ApplicationUserId == userId).ToList().Count,
                QuantitiyCategories = db.Articles.Where(x => x.ApplicationUserId == userId).GroupBy(y => y.Category.CategoryName).ToList().Count,
                QuantitiyTags = db.Articles.Where(x => x.ApplicationUserId == userId).GroupBy(y => y.Tags.FirstOrDefault().Id).ToList().Count,
                QuantitiyComments = db.Articles.Where(x => x.ApplicationUserId == userId).Sum(y => y.Comments.Count)
            };
            return View(pvm);
        }
    }
}