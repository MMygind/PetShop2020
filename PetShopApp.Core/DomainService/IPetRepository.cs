using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadAll(Filter filter = null);
        Pet Create(Pet pet);
        Pet ReadById(int id);
        Pet Update(Pet petUpdate);
        Pet Delete(int id);
        Pet ReadByIdIncludeOwners(int id);

    }
}
