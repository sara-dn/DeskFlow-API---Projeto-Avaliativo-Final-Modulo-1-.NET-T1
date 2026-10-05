using DeskFlow.API.Data;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace DeskFlow.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            //return await _context.Categories.Include(c => c.Tickets).ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();
            foreach(var category in categories)
            {
                category.Tickets = await _context.Tickets.Include(t => t.Interactions).Where(t => t.CategoryId == category.Id).ToListAsync();
            }//to get the interections because otherwise it doesn't do it.
            return categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Tickets).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasTicketsAsync(int id)
        {
            return await _context.Tickets.AnyAsync(t => t.CategoryId == id);
        }
    }
}