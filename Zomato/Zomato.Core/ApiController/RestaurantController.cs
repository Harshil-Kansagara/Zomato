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
    public class RestaurantController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public RestaurantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("restaurant")]
        public RestaurantCollection Index()
        {
            RestaurantCollection _restaurantCollection = new RestaurantCollection();
            _restaurantCollection.Restaurant = _unitOfWork.RestaurantRepository.ListRestaurant();
            List<RestCategory> _restCategory = null;
            List<RestCuisine> _restCuisine = null;

            for (int i=0;i<_restaurantCollection.Restaurant.Count;i++)
            {
                _restCategory = _unitOfWork.RestCategoryRepository.GetRestCategoryByRestaurantId(_restaurantCollection.Restaurant[i].RestaurantId);

                _restCuisine = _unitOfWork.RestCuisineRepository.GetRestCuisinesByRestaurantId(_restaurantCollection.Restaurant[i].RestaurantId);

                _restaurantCollection.RestaurantLocation = _unitOfWork.RestLocationRepository.GetRestLocationById(_restaurantCollection.Restaurant[i].RestaurantId);
            }

            for (int i = 0; i < _restCuisine.Count; i++)
            {
                _restaurantCollection.CuisineCollection.Add(new RestaurantCuisineCollection(_restCuisine[i].RestaurantId, _unitOfWork.CuisineRepository.GetCuisineById(_restCuisine[i].CuisineId)));
            }

            for (int i = 0; i < _restCategory.Count; i++)
            {
                _restaurantCollection.CategoryCollection.Add(new RestaurantCategoryCollection(_restCategory[i].RestaurantId, _unitOfWork.CategoryRepository.GetCategoryById(_restCategory[i].CategoryId)));
            }

            return _restaurantCollection;
        }

        [HttpGet]
        [Route("list")]
        public List<Restaurant> List()
        {
            return _unitOfWork.RestaurantRepository.ListRestaurant();
        }

        [HttpGet]
        [Route("restaurant/{restaurantId}")]
        public RestaurantCollection Detail(int restaurantId)
        {
            RestaurantCollection _restaurantCollection = new RestaurantCollection();
            _restaurantCollection.Restaurant.Add(_unitOfWork.RestaurantRepository.GetRestaurantById(restaurantId));
            List<RestCategory> _restCategory = null;
            List<RestCuisine> _restCuisine = null;

            for (int i = 0; i < _restaurantCollection.Restaurant.Count; i++)
            {
                _restCategory = _unitOfWork.RestCategoryRepository.GetRestCategoryByRestaurantId(restaurantId);

                _restCuisine = _unitOfWork.RestCuisineRepository.GetRestCuisinesByRestaurantId(restaurantId);

                _restaurantCollection.RestaurantLocation = _unitOfWork.RestLocationRepository.GetRestLocationById(restaurantId);
            }

            for (int i = 0; i < _restCuisine.Count; i++)
            {
                _restaurantCollection.CuisineCollection.Add(new RestaurantCuisineCollection(_restCuisine[i].RestaurantId, _unitOfWork.CuisineRepository.GetCuisineById(_restCuisine[i].CuisineId)));
            }

            for (int i = 0; i < _restCategory.Count; i++)
            {
                _restaurantCollection.CategoryCollection.Add(new RestaurantCategoryCollection(_restCategory[i].RestaurantId, _unitOfWork.CategoryRepository.GetCategoryById(_restCategory[i].CategoryId)));
            }
            return _restaurantCollection;
        }

        [HttpPost]
        [Route("restaurant")]
        public IActionResult Create(NewRestaurant newRestaurant)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.RestaurantName = newRestaurant.RestaurantName;
            restaurant = _unitOfWork.RestaurantRepository.AddRestaurant(restaurant);

            for (int i = 0; i < newRestaurant.Location.Count; i++) { 
                RestaurantLocation restaurantLocation = new RestaurantLocation();
                restaurantLocation.RestaurantId = restaurant.RestaurantId;
                restaurantLocation.Location = newRestaurant.Location[i];
                _unitOfWork.RestLocationRepository.AddRestLocation(restaurantLocation);
            }
            
            for(int i = 0; i < newRestaurant.CategoryId.Count; i++) { 
                RestCategory restCategory = new RestCategory();
                restCategory.CategoryId = newRestaurant.CategoryId[i];
                restCategory.RestaurantId = restaurant.RestaurantId;
                _unitOfWork.RestCategoryRepository.AddRestCategory(restCategory);
            }

            for(int i=0;i<newRestaurant.CuisineId.Count; i++) { 
                RestCuisine restCuisine = new RestCuisine();
                restCuisine.CuisineId = newRestaurant.CuisineId[i];
                restCuisine.RestaurantId = restaurant.RestaurantId;
                _unitOfWork.RestCuisineRepository.AddRestCuisine(restCuisine);
            }

            _unitOfWork.commit();
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{restaurantId}")]
        public void DeleteConfirm(int restaurantId)
        {
            try
            {
                _unitOfWork.RestaurantRepository.deleteRestaurant(restaurantId);
                _unitOfWork.commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
