using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PetShopApp.Infrastructure.SQLite.Data.Repositories
{
    public class PetDBRepository : IPetRepository
    {
        private PetShopAppLiteContext _ctx;

        public PetDBRepository(PetShopAppLiteContext ctx)
        {
            _ctx = ctx;
        }
        public Pet Create(Pet pet)
        {
            /*if (pet.Owner != null && _ctx.ChangeTracker.Entries<Pet>().FirstOrDefault(oe => oe.Entity.Id == pet.Owner.Id) == null)
            {
                _ctx.Attach(pet.Owner);
            }
            var petEntry = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return petEntry;*/

            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet Delete(int id)
        {
            var petRemoved = _ctx.Remove(new Pet { Id = id }).Entity;
            _ctx.SaveChanges();
            return petRemoved;
        }

        public Pet ReadByIdIncludeOwners(int id)
        {
            return _ctx.Pets
                .Include(p => p.Owner)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pet> ReadAll(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Pets
                    .Include(p => p.Owner);
            }

            return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            /*if (petUpdate.Owner != null && _ctx.ChangeTracker.Entries<Pet>().FirstOrDefault(oe => oe.Entity.Id == petUpdate.Owner.Id) == null)
            {
                _ctx.Attach(petUpdate.Owner);
            }
            else
            {
                _ctx.Entry(petUpdate).Reference(p => p.Owner).IsModified = true;
            }
            var updated = _ctx.Update(petUpdate).Entity;
            _ctx.SaveChanges();*/

            _ctx.Attach(petUpdate).State = EntityState.Modified;
            _ctx.Entry(petUpdate).Reference(p => p.Owner).IsModified = true;
            _ctx.SaveChanges();
            return petUpdate;
        }
    }
}
