using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using EntityLayer.Dto;

namespace DataAccessLayer.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByCategoryAsync(int categoryId);

        Task<Product> GetProductByIdAsync(int productId);
    }
}