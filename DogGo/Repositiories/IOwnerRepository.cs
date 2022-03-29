using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;
using Microsoft.Data.SqlClient;


namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);

        Owner GetOwnerByEmail(string email);

       public void AddOwner(Owner owner);

        public void DeleteOwner(int ownerId);
        public void UpdateOwner(Owner owner);

    }
}
