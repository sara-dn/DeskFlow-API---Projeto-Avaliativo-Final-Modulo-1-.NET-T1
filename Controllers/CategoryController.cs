using DeskFlow.API.Models.Entities;
using DeskFlow.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using DeskFlow.API.Services.Interfaces;

namespace DeskFlow.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> NewAsync([FromBody]CreateUpdateCategoryDto dto)
        {
            await _categoryService.CreateAsync(dto);
            return Created("/category", dto);  
        }

        [HttpGet]
        public async Task<IActionResult> AllAsync()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ByIdAsync([FromRoute]int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsyn([FromRoute]int id, [FromBody] CreateUpdateCategoryDto dto)
        {
            await _categoryService.UpdateAsync(id, dto);
            return Ok(dto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsyn([FromRoute]int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}