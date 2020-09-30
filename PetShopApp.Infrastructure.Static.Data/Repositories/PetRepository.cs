using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class PetRepository: IPetRepository
    {
        private int id = 1;
        private List<Pet> _pets = new List<Pet>();
        public IEnumerable<Pet> ReadAll(Filter filter)
        {
            return _pets;
        }

        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }

            return null;
        }

        public Pet Update(Pet petUpdate)
        {
            var petFromDB = this.ReadById(petUpdate.Id);
            if (petFromDB != null)
            {
                petFromDB.Name = petUpdate.Name;
                petFromDB.Type = petUpdate.Type;
                petFromDB.Birthdate = petUpdate.Birthdate;
                petFromDB.SoldDate = petUpdate.SoldDate;
                petFromDB.Color = petUpdate.Color;
                petFromDB.PreviousOwner = petUpdate.PreviousOwner;
                petFromDB.Price = petUpdate.Price;
                return petFromDB;
            }

            return null;
        }

        public Pet Delete(int id)
        {
            var petFound = this.ReadById(id);
            if (petFound != null)
            {
                _pets.Remove(petFound);
                return petFound;
            }

            return null;
        }

        public Pet ReadByIdIncludeOwners(int id)
        {
            throw new NotImplementedException();
        }
    }
}
