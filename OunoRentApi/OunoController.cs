using AutoMapper;
using DataAccessLayer.Interface;
using EntityLayer;
using EntityLayer.Dto;
using EntityLayer.Dto.Category;
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

        [HttpGet("products/category/{categoryId:int}")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("products/{productId:int}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpGet("categories", Name = "GetCategories")]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }

        [HttpGet("categories/{categoryId:int}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> GetCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryAsync(categoryId);

            var categoryDtos = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDtos);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);

            dynamic createdCategory = await _categoryRepository.CreateCategoryAsync(category);

            createdCategory = _mapper.Map<CategoryDto>(createdCategory);

            return Ok(createdCategory);
        }

        [HttpPut("category/{categoryId:int}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);

            dynamic updatedCategory = await _categoryRepository.UpdateCategoryAsync(category);

            updatedCategory = _mapper.Map<CategoryDto>(updatedCategory);

            return Ok(updatedCategory);
        }
    }
}