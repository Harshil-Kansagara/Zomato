using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.CuisineRepository
{
    public interface ICuisineRepository
    {
        Cuisine GetCuisineById(int cuisineId);
    }
}
