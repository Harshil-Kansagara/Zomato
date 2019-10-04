using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;
using Zomato.Repository.UnitofWork;

namespace Zomato.Core.ApiController
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
        [Route("restaurant/{restaurantId}/menu")]
        public List<Menu> MenuList(int restaurantId)
        {
            List<Menu> menu = new List<Menu>();
            menu = _unitOfWork.MenuRepository.GetMenuByRestaurantId(restaurantId);
            return menu;
        }

        [HttpPost]
        [Route("restaurant/{restaurantId}/menu")]
        public IActionResult Create(int restaurantId, List<Menu> newMenu)
        {
            for(int i=0; i<newMenu.Count;i++)
            {
                newMenu[i].RestaurantId = restaurantId;
                _unitOfWork.MenuRepository.AddMenuItem(newMenu[i]);
            }
            _unitOfWork.commit();
            return Ok();
        }

        [HttpDelete]
        [Route("restaurant/{restaurantId}/menu/{itemId}")]
        public void DeleteMenu(int restaurantId, int itemId)
        {
            try
            {
                _unitOfWork.MenuRepository.deleteMenu(restaurantId, itemId);
                _unitOfWork.commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
