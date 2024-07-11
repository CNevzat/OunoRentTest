using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using EntityLayer;
using EntityLayer.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _applicatioxnDbContext;

        public ProductRepository(ApplicationDbContext applicatioxnDbContext)
        {
            _applicatioxnDbContext = applicatioxnDbContext;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _applicatioxnDbContext.Products
            .Include(x=> x.Category)
            .Where(x=> x.CategoryId == categoryId)
            .ToListAsync();

            return products;
        }
    }
}