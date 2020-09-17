using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class OwnerService: IOwnerService
    {
        private readonly IOwnerRepository _ownerRepo;
        private readonly IPetRepository _petRepo;
        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepo = ownerRepository;
            _petRepo = petRepository;
        }
        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = FindOwnerById(ownerUpdate.Id);
            owner.Name = ownerUpdate.Name;
            owner.Address = ownerUpdate.Address;
            return owner;
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }

        public Owner FindOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepo.ReadById(id);
            owner.Pets = _petRepo.ReadAll()
                .Where(pet => pet.PreviousOwner.Id == owner.Id)
                .ToList();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.Delete(id);
        }

        public Owner NewOwner(string name, string address)
        {
            var owner = new Owner()
            {
                Name = name,
                Address = address,
            };
            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }
    }
}
