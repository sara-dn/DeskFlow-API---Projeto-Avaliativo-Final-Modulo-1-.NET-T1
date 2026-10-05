using DeskFlow.API.Models.Entities;
using DeskFlow.API.Models.DTOs;
using DeskFlow.API.Services.Interfaces;
using DeskFlow.API.Repositories.Interfaces;


namespace DeskFlow.API.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateAsync(CreateUpdateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
            };
            return await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category != null)
            {
                await _categoryRepository.DeleteAsync(category);
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, CreateUpdateCategoryDto dto)
        {
            var categoryDb = await _categoryRepository.GetByIdAsync(id);
            var updatedCategory = new Category
            {
                Name = dto.Name,
            };
            categoryDb.Update(updatedCategory);
            await _categoryRepository.UpdateAsync(categoryDb);
        }
    }
}