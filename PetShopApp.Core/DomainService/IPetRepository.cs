using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadAll();
        Pet Create(Pet pet);
        Pet ReadById(int id);
        Pet Update(Pet petUpdate);
        Pet Delete(int id);

    }
}
