using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int categoryId);
    }
}
