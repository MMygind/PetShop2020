using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data
{
    public class DataInitializer
    {
        private readonly IPetRepository _petRepo;

        public DataInitializer (IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public void InitData()
        {
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

        }
    }
}
