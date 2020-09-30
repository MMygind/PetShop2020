using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        List<Pet> GetFilteredPets(Filter filter);
        Pet UpdatePet(Pet petUpdate);
        Pet FindPetById(int id);
        Pet FindPetByIdIncludeOwners(int id);
        List<Pet> GetAllByPrice();
        Pet DeletePet(int id);

        Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string previousOwner,
            double price);

        Pet CreatePet(Pet pet);
        List<Pet> GetAllByType(string type);
        List<Pet> ShowFiveCheapest();

    }
}
