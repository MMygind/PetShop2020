using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        private int id = 1;
        private List<Owner> _owners = new List<Owner>();
        public IEnumerable<Owner> ReadAll()
        {
            return _owners;
        }

        public Owner Create(Owner owner)
        {
            owner.Id = id++;
            _owners.Add(owner);
            return owner;
        }

        public Owner ReadById(int id)
        {
            foreach (var owner in _owners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }

            return null;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var ownerFromDB = this.ReadById(ownerUpdate.Id);
            if (ownerFromDB != null)
            {
                ownerFromDB.Name = ownerUpdate.Name;
                ownerFromDB.Address = ownerUpdate.Address;

                return ownerFromDB;
            }

            return null;
        }

        public Owner Delete(int id)
        {
            var ownerFound = this.ReadById(id);
            if (ownerFound != null)
            {
                _owners.Remove(ownerFound);
                return ownerFound;
            }

            return null;
        }

        public Owner ReadByIdIncludePets(int id)
        {
            throw new NotImplementedException();
        }
    }
}
