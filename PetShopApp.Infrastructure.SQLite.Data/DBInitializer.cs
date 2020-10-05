using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using PetShopApp.Core.Entity;

namespace PetShopApp.Infrastructure.SQLite.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetShopAppLiteContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var owner1 = ctx.Owners.Add(new Owner()
            {
                Name = "Michael",
                Address = "Billy Jean"
            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                Name = "Harry",
                Address = "Under the stairs"
            }).Entity;

            ctx.Pets.Add(new Pet()
            {
                Name = "Bob",
                Type = "Dog",
                Birthdate = new DateTime(2019, 05, 05),
                SoldDate = new DateTime(2020, 05, 05),
                Color = "Brown",
                PreviousOwner = "Some guy",
                Price = 5000.00,
                Owner = owner1
            });

            ctx.Pets.Add(new Pet()
            {
                Name = "Billy",
                Type = "Cat",
                Birthdate = new DateTime(2019, 05, 05),
                SoldDate = new DateTime(2020, 05, 05),
                Color = "Black",
                PreviousOwner = "Michael",
                Price = 400.00,
                Owner = owner2
            });

            // Look for any TodoItems
            if (ctx.TodoItems.Any())
            {
                return;   // DB has been seeded
            }

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem { IsComplete=true, Name="Make homework"},
                new TodoItem { IsComplete=false, Name="Sleep"}
            };

            // Create two users with hashed and salted passwords
            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    Password = "1234",
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    Password = "1234",
                    IsAdmin = true
                }
            };

            ctx.TodoItems.AddRange(items);
            ctx.Users.AddRange(users);


            ctx.SaveChanges();
        }
    }
}
