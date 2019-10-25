using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.MenuRepository
{
    public class MenuRepository : IMenuRepository
    {
        private ApplicationDbContext _db;

        public MenuRepository(ApplicationDbContext db)
        {
            _db=db;
        }

        public async Task<Menu> AddMenuItem(Menu menu)
        {
            await _db.Menu.AddAsync(menu);
            return menu;
        }

        public async Task DeleteMenu(int restaurantId, int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetItemPriceByItemId(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Menu>> GetMenuByRestIdAndCuisineId(int restaurantId, int cuisineId)
        {
            return await _db.Menu.Where(x => x.RestaurantId == restaurantId && x.CuisineId == cuisineId).ToListAsync();
        }

        public async Task<string> GetMenuNameByItemId(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
