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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Pets)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
