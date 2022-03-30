using DogGo.Models;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IWalksRepository
    {
        List<Walk> GetAllWalks();
        List<Walk> GetWalksByWalkerId(int walkerId);
    }
}