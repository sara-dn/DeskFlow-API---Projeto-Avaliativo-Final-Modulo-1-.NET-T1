using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Models.DTOs;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Services.Interfaces;

namespace DeskFlow.API.Services
{
    public class TicketService : ITicketService
    {
        private ITicketRepository _context;

        public TicketService(ITicketRepository context)
        {
            _context = context;
        }
        public async Task<Ticket> CreateTicketAsync(CreateTicketDto dto)
        {
            var newTicket = new Ticket()
            {
                Title = dto.Title,
                Description = dto.Description,
                RequesterName = dto.RequesterName,
                OpenedDate = dto.OpenedDate,
                Priority = dto.Priority,
                Status = dto.Status,
                CategoryId = dto.CategoryId
            };

            throw new NotImplementedException();
        }

        public async Task<Ticket> StartTicketAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> CloseTicketAsync(int id, CloseTicketDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> AddInteractionAsync(int id, CreateInteractionDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllAsync(string status, string priority, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}