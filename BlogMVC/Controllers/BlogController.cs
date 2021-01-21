using BlogMVC.Areas.Admin.ViewModel;
using BlogMVC.Models;
using BlogMVC.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class BlogController : BaseController
    {

        // GET: Blog
        public ActionResult Index()
        {
            var tags = db.Tags.ToList();
            foreach (var item in tags)
            {
                if (item.Articles.Count == 0)
                {
                    db.Tags.Remove(item);
                    db.SaveChanges();
                }
            }
            var vmb = new HomeBlogViewModel()
            {
                Articles = db.Articles.ToList(),
                Categories = db.Categories.ToList(),
                Tags = db.Tags.ToList(),
            };
            return View(vmb);
        }

        public ActionResult CategoryBlog(int ? id)
        {
            if (id != null)
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                ViewBag.categoryName = category.CategoryName;
                var articles = db.Articles.Where(x => x.CategoryId == category.Id).ToList();
                var vmb = new HomeBlogViewModel()
                {
                    Articles = articles,
                    Categories = db.Categories.ToList(),
                    Tags = db.Tags.ToList()
                };
                return View(vmb);
            }
            return new EmptyResult();
        }
        public ActionResult TagsBlog(int? id)
        {
            if (id != null)
            {
                var tag = db.Tags.FirstOrDefault(x => x.Id == id);
                ViewBag.tagName = tag.TagName;
                var articles = db.Articles.Where((x => x.Tags.FirstOrDefault().Id==tag.Id)).ToList();
                var vmb = new HomeBlogViewModel()
                {
                    Articles = articles,
                    Categories = db.Categories.ToList(),
                    Tags = db.Tags.ToList()
                };
                return View(vmb);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailSub(string email)
        {
            string mesaj = "";
            var _email = new EmailSub() { Email = email };

            if (ModelState.IsValid && !string.IsNullOrEmpty(_email.Email))                     
            {

                if (db.EmailSubs.Any(x => x.Email == _email.Email))
                {
                    mesaj = "Bu mail sisteme kayıtlı.";
                }
                else
                {
                    var emailSub = new EmailSub() { Email = _email.Email };
                    db.EmailSubs.Add(emailSub);
                    db.SaveChanges();
                    mesaj = "İşlem Başarılı";
                }
            }
            else
            {
                mesaj = "Hatalı işlem";
            }
            return Json(mesaj);

        }

        public ActionResult BlogTek(int? id)
        {
            if (id !=null)
            {
                var article = db.Articles.FirstOrDefault(x => x.Id == id);
                var categoryName = article.Category.CategoryName;
                if (db.Articles.Where(x => x.Category.CategoryName == categoryName).ToList().Count >= 3)
                {
                    ViewBag.relatedArticles = db.Articles.Where(x => x.Category.CategoryName == categoryName).Take(3).ToList();
                }
                return View(article);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel CommentViewModel)
        {
            Comment comment;
            if (ModelState.IsValid)
            {
                comment = new Comment()
                {
                    ApplicationUserId = User.Identity.GetUserId(),
                    CommentText = CommentViewModel.CommentText,
                    ArticleId = CommentViewModel.ArticleId,
                    PostedDate = DateTime.Now,
                    CommentAuthor = User.Identity.GetUserName().Substring(0, User.Identity.GetUserName().IndexOf("@"))
                };db.Comments.Add(comment);
                db.SaveChanges();
                return Json(comment);
            }
            else
            {
                if (CommentViewModel.CommentText.Length > 500)
                {
                    return Json("uzunlukHatasi");
                }
                return Json("hata");
            }
        }

        public ActionResult Like(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();

            if (db.Users.FirstOrDefault(x =>x.Id == userId).Likes.Any(x =>x.ArticleId == id))
            {
                var user = db.Users.Find(userId);
                var like = db.Likes.ToList().Where(x => x.applicationUser == user).FirstOrDefault(x => x.ArticleId == id);
                var article = db.Articles.Find(id);
                user.Likes.Remove(like);
                article.Likes.Remove(like);
                db.Likes.Remove(like);
                db.SaveChanges();
                //var toplam = db.Articles.Find(id);
                //var toplamLike = toplam.Likes.Count;
                return Json("unlike");

            }
            else
            {
                Like like = new Like();
                ApplicationUser user = db.Users.Find(userId);
                Article article = db.Articles.Find(id);
                user.Likes.Add(like);
                article.Likes.Add(like);
                db.Likes.Add(like);
                db.SaveChanges();
                //var toplam = db.Articles.Find(id);
                //var toplamLike = toplam.Likes.Count;
                return Json("like");
            }
        }
    }
}