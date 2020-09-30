using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PetShopApp.Infrastructure.SQLite.Data.Repositories
{
    public class OwnerDBRepository : IOwnerRepository
    {
        private PetShopAppLiteContext _ctx;

        public OwnerDBRepository(PetShopAppLiteContext ctx)
        {
            _ctx = ctx;
        }
        public Owner Create(Owner owner)
        {
            var ownerSaved = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return ownerSaved;
        }

        public Owner Delete(int id)
        {
            var ownerRemoved = _ctx.Remove(new Owner { Id = id }).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }

        public Owner ReadByIdIncludePets(int id)
        {
            return _ctx.Owners
                .Include(o => o.Pets)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners
                .Include(o => o.Pets);
        }

        public Owner ReadById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            _ctx.Attach(ownerUpdate).State = EntityState.Modified;
            _ctx.Entry(ownerUpdate).Collection(o => o.Pets).IsModified = true;
            var pets = _ctx.Pets.Where(p => p.Owner.Id == ownerUpdate.Id
                                            && !ownerUpdate.Pets.Exists(po => po.Id == p.Id));

            foreach (var pet in pets)
            {
                pet.Owner = null;
                _ctx.Entry(pet).Reference(p => p.Owner).IsModified = true;
            }
            _ctx.SaveChanges();
            return ownerUpdate;
        }
    }
}
