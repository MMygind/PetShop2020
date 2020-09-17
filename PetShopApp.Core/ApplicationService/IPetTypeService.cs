using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetTypeService
    {
        List<PetType> GetAllPetTypes();
        PetType UpdatePetType(PetType petTypeUpdate);
        PetType FindPetTypeById(int id);

        PetType DeletePetType(int id);

        PetType NewPetType(string name);

        PetType CreatePetType(PetType petType);
    }
}
