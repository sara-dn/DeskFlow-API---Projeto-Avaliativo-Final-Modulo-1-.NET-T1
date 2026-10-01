using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Services.Interfaces;
using DeskFlow.API.Repositories.Interfaces;
using System.Security.Cryptography;

namespace DeskFlow.API.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(Category category)
        {
            await _categoryRepository.CreateAsync(category);
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

        public async Task UpdateAsync(int id, Category category)
        {
            var categoryDb = await _categoryRepository.GetByIdAsync(id);

            if(categoryDb == null)
            {
                throw new Exception("Category not found");
            }

            categoryDb.Update(category);

            await _categoryRepository.UpdateAsync(categoryDb);
        }
    }
}