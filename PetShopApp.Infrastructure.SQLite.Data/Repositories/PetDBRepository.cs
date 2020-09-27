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
            var petEntry = _ctx.Add(pet);
            _ctx.SaveChanges();
            return petEntry.Entity;
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

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets
                .Include(p => p.Owner);
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
