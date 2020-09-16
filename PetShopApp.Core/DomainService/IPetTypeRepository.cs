using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.DomainService
{
    public interface IPetTypeRepository
    {
        IEnumerable<PetType> ReadAll();
        PetType Create(PetType petType); 
        PetType ReadById(int id);
        PetType Update(PetType petUpdate);
        PetType Delete(int id);
    }
}
