using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.CuisineRepository
{
    public class CuisineRepository : ICuisineRepository
    {
        private readonly ApplicationDbContext _db;

        public CuisineRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Cuisine>> CuisineList()
        {
            return await _db.Cuisine.ToListAsync();
        }

        public async Task<string> GetCuisineById(int cuisineId)
        {
            var cuisine = await _db.Cuisine.Where(x => x.CuisineId == cuisineId).FirstAsync();
            return cuisine.CuisineName;
        }
    }
}
