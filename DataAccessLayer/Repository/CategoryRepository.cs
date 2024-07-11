using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _applicatioxnDbContext;

        public CategoryRepository(ApplicationDbContext applicatioxnDbContext)
        {
            _applicatioxnDbContext = applicatioxnDbContext;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _applicatioxnDbContext.Categories
            .ToListAsync();

            return categories;
        }
    }
}