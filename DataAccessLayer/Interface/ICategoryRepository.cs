using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Dto;
using EntityLayer.Entities;

namespace DataAccessLayer.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryAsync(int categoryId);

        Task<Category> CreateCategoryAsync(Category category); 

        Task<Category> UpdateCategoryAsync(Category category);
    }
}