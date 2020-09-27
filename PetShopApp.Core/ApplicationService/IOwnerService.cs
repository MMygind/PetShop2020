using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();
        Owner UpdateOwner(Owner ownerUpdate);
        Owner FindOwnerById(int id);
        Owner FindOwnerByIdIncludePets(int id);
        Owner DeleteOwner(int id);

        Owner NewOwner(string name, string address);

        Owner CreateOwner(Owner owner);
        List<Owner> GetAllByName(string name);
    }
}
