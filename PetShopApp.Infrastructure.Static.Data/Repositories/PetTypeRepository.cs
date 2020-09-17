using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class PetTypeRepository: IPetTypeRepository
    {
        private int id = 1;
        private List<PetType> _petTypes = new List<PetType>();
        public IEnumerable<PetType> ReadAll()
        {
            return _petTypes;
        }

        public PetType Create(PetType petType)
        {
            petType.Id = id++;
            _petTypes.Add(petType);
            return petType;
        }

        public PetType ReadById(int id)
        {
            foreach (var petType in _petTypes)
            {
                if (petType.Id == id)
                {
                    return petType;
                }
            }

            return null;
        }

        public PetType Update(PetType petTypeUpdate)
        {
            var petTypeFromDB = this.ReadById(petTypeUpdate.Id);
            if (petTypeFromDB != null)
            {
                petTypeFromDB.Name = petTypeUpdate.Name;

                return petTypeFromDB;
            }

            return null;
        }

        public PetType Delete(int id)
        {
            var petTypeFound = this.ReadById(id);
            if (petTypeFound != null)
            {
                _petTypes.Remove(petTypeFound);
                return petTypeFound;
            }

            return null;
        }
    }
}

