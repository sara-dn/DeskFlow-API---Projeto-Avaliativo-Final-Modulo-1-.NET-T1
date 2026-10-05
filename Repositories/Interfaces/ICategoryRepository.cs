using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<Category> CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task<bool> HasTicketsAsync(int id);
    }
}