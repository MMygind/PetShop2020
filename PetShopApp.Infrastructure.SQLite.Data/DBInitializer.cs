using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.SQLite.Data.Helpers;

namespace PetShopApp.Infrastructure.SQLite.Data
{
    public class DBInitializer: IDBInitializer
    {
        private IAuthenticationHelper authenticationHelper;

        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }
        public void SeedDB(PetShopAppLiteContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            if (ctx.TodoItems.Any())
            {
                return;
                //ctx.Database.ExecuteSqlRaw("DROP TABLE Pets");
                //ctx.Database.ExecuteSqlRaw("DROP Table Owner");
                //ctx.Database.ExecuteSqlRaw("DROP Table Todo");
                //ctx.Database.ExecuteSqlRaw("DROP Table Token");
                //ctx.Database.EnsureCreated();
            }

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

            //Look for any TodoItems
            

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem { IsComplete=true, Name="Make homework"},
                new TodoItem { IsComplete=false, Name="Sleep"}
            };

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            //Create two users with hashed and salted passwords
            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.TodoItems.AddRange(items);
            ctx.Users.AddRange(users);


            ctx.SaveChanges();
        }
    }
}
