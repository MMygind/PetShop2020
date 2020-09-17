﻿using PetShopApp.Core.DomainService;
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

        public static readonly List<PetType> PetTypes = new List<PetType>();
        public static readonly List<Owner> Owners = new List<Owner>();


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
            PetTypes.Add(petType1);

            var owner1 = new Owner()
            {
                Name = "Michael Jackson",
                Address = "Billy Jean"
            };
            _ownerRepo.Create(owner1);
            Owners.Add(owner1);

            var pet1 = new Pet()
            {
                Name = "Bob",
                Type = petType1,
                Birthdate = new DateTime(2019, 05, 05),
                SoldDate = new DateTime(2020, 05, 05),
                Color = "Brown",
                PreviousOwner = owner1,
                Price = 5000.00
            };
            _petRepo.Create(pet1);

            var pet2 = new Pet()
            {
                Name = "Billy",
                Type = petType1,
                Birthdate = new DateTime(2018, 05, 04),
                SoldDate = new DateTime(2019, 04, 04),
                Color = "Black",
                PreviousOwner = owner1,
                Price = 50.00
            };
            _petRepo.Create(pet2);

            

            

        }
    }
}
