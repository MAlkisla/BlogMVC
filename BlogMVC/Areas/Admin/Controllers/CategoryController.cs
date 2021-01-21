using BlogMVC.Areas.Admin.ViewModel;
using BlogMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        // GET: Admin/Category
        public ActionResult Index(string sonuc)
        {
            ViewBag.sonuc = sonuc;
            var categories = new List<CategoryViewModel>();
            var userId = User.Identity.GetUserId();
            for (int i = 0; i < db.Categories.ToList().Count; i++)
            {
                var turnCategory = db.Categories.ToList()[i];
                var category = new CategoryViewModel()
                {
                    Id = turnCategory.Id,
                    CategoryName = turnCategory.CategoryName,
                    QuantityC = turnCategory.Articles.Where(x => x.ApplicationUserId == userId).ToList().Count
                };
                categories.Add(category);
            }
            return View(categories);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == id);
            if (category.Articles.Count == 0)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("Index", new { sonuc = "silindi" });
            }
            else
            {
                return RedirectToAction("Index", new { sonuc = "silinemez" });

            }
        }

        public ActionResult NewCategory()
        {
            
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult NewCategory(Category category)
        {
            category.CategoryName = capitalize(category.CategoryName);
            var categoryName = category.CategoryName; 
            if (db.Categories.ToList().Any(x => x.CategoryName == categoryName))
            {
                ViewBag.sonuc = "Aynı isimde kategori oluşturamazsın.";
                return View();
            }
            if (ModelState.IsValid)
            {
                
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public string capitalize(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);

        }
    }
}