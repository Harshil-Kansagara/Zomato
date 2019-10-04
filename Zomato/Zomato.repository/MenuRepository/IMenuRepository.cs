using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.MenuRepository
{
    public interface IMenuRepository
    {
        List<Menu> GetMenuByRestaurantId(int restaurantId);
        Menu AddMenuItem(Menu menu);
        void DeleteMenu(int restaurantId, int itemId);
        string GetMenuNameByItemId(int itemId);
        int GetItemPriceByItemId(int itemId);
    }
}
