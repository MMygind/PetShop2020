using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var ownerEntry = _ctx.Add(owner);
            _ctx.SaveChanges();
            return ownerEntry.Entity;
        }

        public Owner Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners;
        }

        public Owner ReadById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public Owner Update(Owner petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
