using BlogMVC.Areas.Admin.ViewModel;
using BlogMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    public class ArticlesController : AdminController
    {
        // GET: Admin/Articles
        public ActionResult Index()
        {
            if (db.Articles.Any())
            {
                var deneme = User.Identity.GetUserId();
                var articles = db.Articles.Where(x => x.User.Id == deneme).ToList();
                return View(articles);
            }
            return View();
        }

        public ActionResult NewArticle()
        {
            ViewBag.categories = db.Categories.ToList();
            return View();
        }
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult NewArticle(Article article, List<string> tags, HttpPostedFileBase file)
        {

            if (file != null && article != null)
            {
                string path = @"/Images/" + file.FileName;
                article.ArticlePhoto = path;
                file.SaveAs(Server.MapPath("~") + path);

                var deneme = tags[1];
                string[] tagFinal = deneme.Split(',');
                for (int i = 0; i < tagFinal.Length; i++)
                {
                    var deneme2 = tagFinal[i];
                    if (!db.Tags.Any(x => x.TagName == deneme2))
                    {
                        Tag eklenecek = new Tag { TagName = tagFinal[i] };
                        db.Tags.Add(eklenecek);
                        article.Tags.Add(eklenecek);

                    }
                    else
                    {
                        Tag eklenecekMevcutsa = db.Tags.FirstOrDefault(x => x.TagName == deneme2);
                        article.Tags.Add(eklenecekMevcutsa);
                    }
                }
                article.ApplicationUserId = User.Identity.GetUserId();
                article.Author = User.Identity.GetUserName().Substring(0, User.Identity.GetUserName().IndexOf("@"));
                article.PostedDate = DateTime.Now;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categories = db.Categories.ToList();
            return View();
        }

        public ActionResult Delete(int? id)
        {
            var article = db.Articles.FirstOrDefault(x => x.Id == id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditArticle(int? id)
        {
            var article = db.Articles.FirstOrDefault(x => x.Id == id);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.tags = article.Tags.ToList();
            return View(article);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditArticle(Article article, List<string> tags, HttpPostedFileBase file, string yol)
        {
            if (article != null)
            {
                if (file == null)
                {
                    article.ArticlePhoto = yol;
                }
                else
                {
                    string path = @"/Images/" + file.FileName;
                    article.ArticlePhoto = path;
                    file.SaveAs(Server.MapPath("~") + path);
                }

                var deneme = tags[1];
                string[] tagFinal = deneme.Split(',');
                for (int i = 0; i < tagFinal.Length; i++)
                {
                    var deneme2 = tagFinal[i];
                    if (!db.Tags.Any(x => x.TagName == deneme2))
                    {
                        Tag eklenecek = new Tag { TagName = tagFinal[i] };
                        db.Tags.Add(eklenecek);
                        article.Tags.Add(eklenecek);
                    }
                    else
                    {
                        Tag eklenecekMevcutsa = db.Tags.FirstOrDefault(x => x.TagName == deneme2);
                        article.Tags.Add(eklenecekMevcutsa);
                    }
                }
                article.ApplicationUserId = User.Identity.GetUserId();
                db.Entry(article).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}