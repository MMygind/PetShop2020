using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Infrastructure.SQLite.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetShopAppLiteContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Bob",
                Type = "Dog",
                Birthdate = new DateTime(2019, 05, 05),
                SoldDate = new DateTime(2020, 05, 05),
                Color = "Brown",
                PreviousOwner = "Some guy",
                Price = 5000.00
            }).Entity;

            ctx.Pets.Add(new Pet()
            {
                Name = "Billy",
                Type = "Cat",
                Birthdate = new DateTime(2019, 05, 05),
                SoldDate = new DateTime(2020, 05, 05),
                Color = "Black",
                PreviousOwner = "Michael",
                Price = 400.00
            });

            ctx.Owners.Add(new Owner()
            {
                Name = "Michael",
                Address = "Billy Jean"
            });
            ctx.SaveChanges();
        }
    }
}
