using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.SQLite.Data
{
    public class PetShopAppLiteContext: DbContext
    {
        public PetShopAppLiteContext(DbContextOptions<PetShopAppLiteContext> opt) : base(opt) { }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
