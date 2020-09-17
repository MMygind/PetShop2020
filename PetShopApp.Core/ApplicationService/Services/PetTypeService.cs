using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class PetTypeService: IPetTypeService
    {
        private readonly IPetTypeRepository _petTypeRepo;
        private readonly IPetRepository _petRepo;
        public PetTypeService(IPetTypeRepository petTypeRepository, IPetRepository petRepository)
        {
            _petTypeRepo = petTypeRepository;
            _petRepo = petRepository;
        }
        public List<PetType> GetAllPetTypes()
        {
            return _petTypeRepo.ReadAll().ToList();
        }

        public PetType UpdatePetType(PetType petTypeUpdate)
        {
            var petType = FindPetTypeById(petTypeUpdate.Id);
            petType.Name = petTypeUpdate.Name;
            return petType;
        }

        public PetType FindPetTypeById(int id)
        {
            return _petTypeRepo.ReadById(id);
        }


        public PetType DeletePetType(int id)
        {
            return _petTypeRepo.Delete(id);
        }

        public PetType NewPetType(string name)
        {
            var petType = new PetType()
            {
                Name = name
            };
            return petType;
        }

        public PetType CreatePetType(PetType petType)
        {
            return _petTypeRepo.Create(petType);
        }
    }
}
