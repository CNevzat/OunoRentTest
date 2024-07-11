using AutoMapper;
using DataAccessLayer.Interface;
using EntityLayer;
using EntityLayer.Dto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OunoRentApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class OunoController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;
        public OunoController(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("products/{categoryId:int}")]
        public async Task<ActionResult<List<ProductDto>>> GetProductsByCategoryId(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return Ok(categoryDtos);
        }
    }
}