using DeskFlow.API.Models.Entities;
using DeskFlow.API.Models.DTOs;
using DeskFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            var query = _context.Tickets.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                query = query.Where(t => t.Status == filter.Status);
            }

            if (!string.IsNullOrWhiteSpace(filter.Priority))
            {
            query = query.Where(t => t.Priority == filter.Priority);
            }

            if (filter.CategoryId > 0)
            {
                query = query.Where(t => t.CategoryId == filter.CategoryId);
            }

        return await query.ToListAsync();
        }

        public async Task<Ticket> GetByIdForInteractionsAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }
    }
}