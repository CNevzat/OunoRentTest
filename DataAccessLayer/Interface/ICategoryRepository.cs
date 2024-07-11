using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Entities;

namespace DataAccessLayer.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
    }
}