using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.MenuRepository
{
    public class MenuRepository : IMenuRepository
    {
        public Menu AddMenuItem(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void DeleteMenu(int restaurantId, int itemId)
        {
            throw new NotImplementedException();
        }

        public int GetItemPriceByItemId(int itemId)
        {
            throw new NotImplementedException();
        }

        public List<Menu> GetMenuByRestaurantId(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public string GetMenuNameByItemId(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
