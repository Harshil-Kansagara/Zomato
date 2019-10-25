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
    public class CuisineController
    {
        private IUnitOfWork _unitOfWork;

        public CuisineController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<Cuisine>> CuisineList()
        {
            return await _unitOfWork.CuisineRepository.CuisineList();
        }

        [HttpPost]
        public async Task<List<string>> CuisineNameById(List<int> cuisineId)
        {
            List<string> cuisineName = new List<string>();
            foreach(int id in cuisineId)
            {
                cuisineName.Add(await _unitOfWork.CuisineRepository.GetCuisineById(id));
            }

            return cuisineName;
        }
    }
}
