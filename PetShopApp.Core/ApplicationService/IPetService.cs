using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        Pet UpdatePet(Pet petUpdate);
        Pet FindPetById(int id);
        List<Pet> GetAllByPrice();
        Pet DeletePet(int id);

        Pet NewPet(string name, PetType type, DateTime birthDate, DateTime soldDate, string color, Owner previousOwner,
            double price);

        Pet CreatePet(Pet pet);
        List<Pet> GetAllByType(string type);
        List<Pet> ShowFiveCheapest();

    }
}
