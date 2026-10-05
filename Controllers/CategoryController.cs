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
            return Created("api/category", dto);  //201 status code for successful creation of a category
        }

        [HttpGet]
        public async Task<IActionResult> AllAsync()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            if(categories == null)
            {
                return NoContent();//204 no content
            }
            return Ok(categories);//200 Ok, all good
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ByIdAsync([FromRoute]int id)
        {
            
            Category category = await _categoryService.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound();//404 not found
            }
            return Ok(category);//200 Ok, all good
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsyn([FromRoute]int id, [FromBody] CreateUpdateCategoryDto dto)
        {
            if(await _categoryService.GetByIdAsync(id) == null)
            {
                return NotFound();//404 not found
            }
            await _categoryService.UpdateAsync(id, dto);
            return Ok(dto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsyn([FromRoute]int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();//204 no content, because it was either deleted or doen't exist
        }
    }
}