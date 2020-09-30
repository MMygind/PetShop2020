using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }
        public List<Pet> GetAllPets()
        {
            return _petRepo.ReadAll().ToList();
        }

        public List<Pet> GetFilteredPets(Filter filter)
        {
            if (filter == null || (filter.ItemsPrPage == 0 && filter.CurrentPage == 0))
            {
                return _petRepo.ReadAll().ToList();
            }
            return _petRepo.ReadAll(filter).ToList();
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            return _petRepo.Update(petUpdate);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public Pet FindPetByIdIncludeOwners(int id)
        {
            var pet = _petRepo.ReadByIdIncludeOwners(id);
            return pet;
        }


        public Pet DeletePet(int id)
        {
            return _petRepo.Delete(id);
        }

        public Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string previousOwner,
            double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                Birthdate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public List<Pet> GetAllByType(string type)
        {
            var list = _petRepo.ReadAll();
            var queryContinued = list.Where(pet => pet.Type.Equals(type));
            return queryContinued.ToList();
        }

        public List<Pet> GetAllByPrice()
        {
            var list = _petRepo.ReadAll();
            var queryOrdered = list.OrderBy(pet => pet.Price);
            return queryOrdered.ToList();
        }

        public List<Pet> ShowFiveCheapest()
        {
            var list = _petRepo.ReadAll();
            var queryOrdered = list.OrderBy(pet => pet.Price);
            var firstFiveItems = queryOrdered.Take(5);
            return firstFiveItems.ToList();
        }

    }
}
