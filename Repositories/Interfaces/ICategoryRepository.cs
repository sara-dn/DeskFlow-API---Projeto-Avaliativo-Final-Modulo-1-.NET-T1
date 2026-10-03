using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskFlow.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<Category> CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}