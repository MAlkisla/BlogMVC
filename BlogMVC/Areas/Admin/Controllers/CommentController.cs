using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    public class CommentController : AdminController
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var comments = db.Comments.Where(x => x.Article.ApplicationUserId == userId).ToList();
            return View(comments);
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var comment = db.Comments.Find(id);
                db.Comments.Remove(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}