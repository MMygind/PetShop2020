using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets;
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
