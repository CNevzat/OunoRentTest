using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using EntityLayer;
using EntityLayer.Dto;
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

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await IsExistCategory(category.Name);

            await _applicatioxnDbContext.AddAsync(category);

            await _applicatioxnDbContext.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = await _applicatioxnDbContext.Categories
            .ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            var category = await _applicatioxnDbContext.Categories
                .Where(x => x.Id == categoryId)
                .FirstOrDefaultAsync()
                ?? throw new ArgumentException("Kategori bulunamadı");

            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
             _applicatioxnDbContext.Update(category);

            await _applicatioxnDbContext.SaveChangesAsync();

            return category;
        }

        private async Task<bool> IsExistCategory(string categoryName)
        {
            var lowercaseCategoryName = categoryName.Trim().ToLower();

            var isExistCategory = await _applicatioxnDbContext.Categories
                .AsNoTracking()
                .AnyAsync(x => x.Name.Trim().ToLower() == lowercaseCategoryName);

                if(isExistCategory)
                {
                    throw new ArgumentException("Kategori zaten var");
                }

            return isExistCategory;
        }
    }
}