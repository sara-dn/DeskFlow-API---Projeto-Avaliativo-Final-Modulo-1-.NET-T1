using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using DeskFlow.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using DeskFlow.API.Services.Interfaces;

namespace DeskFlow.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private ICategoryInterface _categoryService;
        public CategoryController(ICategoryInterface categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> NewAsync([FromBody]Category category)
        {
            //todo: implement writing logic using services
            return Created("/category", category);  
        }

        [HttpGet]
        public async Task<IActionResult> AllAsync()
        {
            List<Category> categories = new();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ByIdAsync([FromRoute]int id)
        {
            Category category = new();
            return Ok(category);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsyn([FromRoute]int id, [FromBody] Category category)
        {
            //todo: implement update logic
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsyn([FromRoute]int id)
        {
            //todo: delete logic
            return Ok();
        }
    }
}