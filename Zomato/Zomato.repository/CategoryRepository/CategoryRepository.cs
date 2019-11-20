using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> CategoryList()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<string> GetCategoryById(int categoryId)
        {
            var category = await _db.Category.Where(x => x.CategoryId == categoryId).FirstAsync();
            return category.CategoryName;
        }

        public async Task<int> GetCategoryIdByName(string categoryName)
        {
            var category = await _db.Category.Where(x => x.CategoryName == categoryName).FirstOrDefaultAsync();
            return category.CategoryId;
        }
    }
}
