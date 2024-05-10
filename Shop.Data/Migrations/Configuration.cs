namespace Shop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shop.Models.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Data.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shop.Data.ShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            CreateProductCategorySample(context);
            CreateProductSample(context);
            CreateApplicationUserSample(context);
        }

        private void CreateProductCategorySample(Shop.Data.ShopDbContext context)
        {
            if (context.ProductCategoryes.Count() == 0)
            {
                List<ProductCategorye> listProductCategory = new List<ProductCategorye>
            {
                new ProductCategorye(){Name = "Quần Áo Nam" , Alias = "quan-ao-nam" , Status = true},
                new ProductCategorye(){Name = "Quần Áo Nữ" , Alias = "quan-ao-nu" , Status = true},
                new ProductCategorye(){Name = "Phụ Kiện" , Alias = "phu-kien" , Status = true},
                new ProductCategorye(){Name = "Giày Dép" , Alias = "giay-dep" , Status = true}
            };
                context.ProductCategoryes.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateProductSample(Shop.Data.ShopDbContext context)
        {
            if (context.Products.Count() == 0)
            {
                List<Product> listProduct = new List<Product>
            {
                    new Product(){Name = "Áo Sơ Mi Nam" , Alias = "ao-so-mi-nam" ,CategoryID = 3, Price = 299 , Status = true},
                    new Product(){Name = "Quần Âu Nam" , Alias = "quan-au-nam" ,CategoryID = 3, Price = 250 , Status = true},
                    new Product(){Name = "Áo Vest Nam" , Alias = "ao-vest-nam" ,CategoryID = 3, Price = 1200 , Status = true},
                    new Product(){Name = "Quần KaKi Nam" , Alias = "quan-kaki-Nam" ,CategoryID = 3, Price = 250 , Status = false}
            };
                context.Products.AddRange(listProduct);
                context.SaveChanges();
            }
        }

        private void CreateApplicationUserSample(ShopDbContext context)
        {
            //This method will be called after migrating to the latest version.
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var user = new ApplicationUser()
            {
                UserName = "ToanLV",
                Email = "toanlvhe173348@fpt.edu.vn",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Lê Văn Toàn"
            };

            manager.Create(user, "11110000");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("toanlvhe173348@fpt.edu.vn");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            //var user = new ApplicationUser()
            //{
            //    UserName = "toanlee",
            //    Email = "toanlee03@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Lê Văn Toàn"
            //};

            //manager.Create(user, "44448888");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("toanlee03@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}