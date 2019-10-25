using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.UnitofWork;

namespace Zomato.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MenuController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{restaurantName}/menu")]
        public async Task<List<MenuCollection>> MenuList(string restaurantName)
        {
            List<MenuCollection> menuCollections = new List<MenuCollection>();
            restaurantName = restaurantName.Replace('-', ' ');
            var restaurantId = await _unitOfWork.RestaurantRepository.GetRestaurantIdByRestaurantName(restaurantName);

            var _restCuisine = await _unitOfWork.RestCuisineRepository.GetRestCuisinesByRestaurantId(restaurantId);

            foreach(var each in _restCuisine)
            {
                var model = new MenuCollection();
                model.CuisineName = await _unitOfWork.CuisineRepository.GetCuisineById(each.CuisineId);
                model.Menus = await _unitOfWork.MenuRepository.GetMenuByRestIdAndCuisineId(restaurantId, each.CuisineId);

                menuCollections.Add(model);
            }
            return menuCollections;            
        }

        [HttpPost]
        [Route("{restaurantName}/menu")]
        public async Task<IActionResult> Create(string restaurantName, List<Menu> newMenu)
        {
            var restaurantId = 0;
            restaurantName = restaurantName.Replace('-', ' ');
            List<Restaurant> restaurant = await _unitOfWork.RestaurantRepository.ListRestaurant();
            for(int i = 0; i < restaurant.Count; i++)
            {
                if(restaurant[i].RestaurantName == restaurantName)
                {
                    restaurantId = restaurant[i].RestaurantId;
                }
            }

            //List<Menu> menu = new List<Menu>();

            //var menuList = _unitOfWork.MenuRepository.GetMenuByRestaurantId(restaurantId);
            if (ModelState.IsValid) { 

                //for(int i=0;i<menuList.Count;i++)
                //{
                //    for(int j=0;j<newMenu.Count; j++)
                //    {
                //        if (menuList[i].ItemName == newMenu[j].ItemName)
                //        {

                //        }
                //        else
                //        {
                //            menu.Add(newMenu[j]);
                //            if()
                //        }
                //    }
                //}
                for (int i = 0; i < newMenu.Count; i++)
                {
                    newMenu[i].RestaurantId = restaurantId;
                    await _unitOfWork.MenuRepository.AddMenuItem(newMenu[i]);
                }
                _unitOfWork.commit();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("restaurant/{restaurantId}/menu/{itemId}")]
        public async Task DeleteMenu(int restaurantId, int itemId)
        {
            try
            {
                await _unitOfWork.MenuRepository.DeleteMenu(restaurantId, itemId);
                _unitOfWork.commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
