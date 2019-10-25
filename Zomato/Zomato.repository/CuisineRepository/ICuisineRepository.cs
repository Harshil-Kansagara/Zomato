using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.CuisineRepository
{
    public interface ICuisineRepository
    {
        Task<string> GetCuisineById(int cuisineId);
        Task<List<Cuisine>> CuisineList();
    }
}
