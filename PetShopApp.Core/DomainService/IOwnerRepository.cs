using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadAll();
        Owner Create(Owner owner);
        Owner ReadById(int id);
        Owner Update(Owner petUpdate);
        Owner Delete(int id);
        Owner ReadByIdIncludePets(int id);
    }
}
