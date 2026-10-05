using DeskFlow.API.Models.Entities;
using DeskFlow.API.Models.DTOs;

namespace DeskFlow.API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<Category> CreateAsync(CreateUpdateCategoryDto dto);
        Task UpdateAsync(int id, CreateUpdateCategoryDto dto);
        Task DeleteAsync(int id);
    }
}