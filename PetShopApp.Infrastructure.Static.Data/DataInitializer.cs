using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Infrastructure.Static.Data.Repositories;

namespace PetShopApp.Infrastructure.Static.Data
{
    public class DataInitializer
    {
        private readonly IPetRepository _petRepo;
        private readonly IOwnerRepository _ownerRepo;
        private readonly IPetTypeRepository _petTypeRepo;

        public DataInitializer (IPetRepository petRepository, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository)
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
            _petTypeRepo = petTypeRepository;
        }

        public void InitData()
        {
            var petType1 = new PetType()
            {
                Name = "Greyhound"
            };
            _petTypeRepo.Create(petType1);

            var pet1 = new Pet()
            {
                Name = "Bob",
                Type = "Dog",
                Birthdate = new DateTime(2019, 05, 05),
                SoldDate = new DateTime(2020, 05, 05),
                Color = "Brown",
                PreviousOwner = "Some guy",
                Price = 5000.00
            };
            _petRepo.Create(pet1);

            var pet2 = new Pet()
            {
                Name = "Billy",
                Type = "Cat",
                Birthdate = new DateTime(2018, 05, 04),
                SoldDate = new DateTime(2019, 04, 04),
                Color = "Black",
                PreviousOwner = "Some other guy",
                Price = 50.00
            };
            _petRepo.Create(pet2);

            var owner1 = new Owner()
            {
                Name = "Michael",
                Address = "Billy Jean"
            };
            _ownerRepo.Create(owner1);

            

        }
    }
}
