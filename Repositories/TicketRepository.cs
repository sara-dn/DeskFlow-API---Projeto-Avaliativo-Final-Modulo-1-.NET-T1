using DeskFlow.API.Models.Entities;
using DeskFlow.API.Models.DTOs;
using DeskFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DeskFlow.API.Data;

namespace DeskFlow.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            await _context.AddAsync(ticket);           
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> AddInteractionAsync(Ticket ticket, Interaction interaction)
        {
            ticket.Interactions.Add(interaction);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Tickets.AsNoTrackingWithIdentityResolution().Include(t => t.Interactions).Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Ticket>> GetAllAsync(QueryFilterDto filter)
        {
            {
                IQueryable<Ticket> query = _context.Tickets.Include(t => t.Interactions).Include(t => t.Category);//creates a queryble object that allows for dynamic quearies in a single trip to the database

                if (!string.IsNullOrWhiteSpace(filter.Status))
                {
                    query = query.Where(t => t.Status == filter.Status);
                }//add the status query parameter if required

                if (!string.IsNullOrWhiteSpace(filter.Priority))
                {
                    query = query.Where(t => t.Priority == filter.Priority);
                }//add the priority query parameter if required


                if (filter.CategoryId > 0)
                {
                    query = query.Where(t => t.CategoryId == filter.CategoryId);
                }//add the category_id query parameter if required

                return await query.ToListAsync();//does a single sql search with all required parameters
            }
        }

        public async Task<Ticket> GetByIdForInteractionsAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<bool> ValidCategoryId(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}