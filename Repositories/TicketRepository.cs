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
            List<Ticket> tickets = new();

            if (!string.IsNullOrWhiteSpace(filter.Status))//isnullorwhitespace checks if a string is null, empty, or consistes of " "
            {
                tickets = await _context.Tickets.Where(t => t.Status == filter.Status).Include(t => t.Interactions).Include(t => t.Category).ToListAsync();
            }

            if (!string.IsNullOrWhiteSpace(filter.Priority))
            {
                tickets = await _context.Tickets.Where(t => t.Priority == filter.Priority).Include(t => t.Interactions).Include(t => t.Category).ToListAsync();
            }

            if (filter.CategoryId > 0)
            {
                tickets = await _context.Tickets.Where(t => t.CategoryId == filter.CategoryId).Include(t => t.Interactions).Include(t => t.Category).ToListAsync();
            }
            
            return tickets;
        }

        public async Task<Ticket> GetByIdForInteractionsAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }
    }
}