using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Models.DTOs;
using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Services
{
    public class TicketService : ITicketInterface
    {
        public async Task<Ticket> CreateTicketAsync(CreateTicketDto dto)
        {
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