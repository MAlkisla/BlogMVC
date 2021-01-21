namespace BlogMVC.Migrations
{
    using BlogMVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogMVC.Models.ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var kategoriler = new List<Category>();
                context.Categories.Add(new Category { CategoryName = "Teknoloji" });
                context.Categories.Add(new Category { CategoryName = "Moda" });
                context.Categories.Add(new Category { CategoryName = "Otomobil" });
                context.Categories.Add(new Category { CategoryName = "Ekonomi" });
                context.Categories.Add(new Category { CategoryName = "Sağlık" });
            }
        }
    }
}
