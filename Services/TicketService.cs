using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Models.DTOs;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

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
            return await _context.CreateTicketAsync(newTicket);
        }

        public async Task<Ticket> StartTicketAsync(Ticket ticket)
        {
            ticket.Status = "InProgress";
            await _context.UpdateTicketAsync(ticket);
            return ticket;
        }

        public async Task<Ticket> CloseTicketAsync(Ticket ticket, CloseTicketDto dto)
        {
            ticket.Status = dto.Status;
            ticket.Solution = dto.Solution;
            ticket.ClosedDate = dto.ClosedDate;
            await _context.UpdateTicketAsync(ticket);
            throw new NotImplementedException();
        }

        public async Task<Ticket> AddInteractionAsync(Ticket ticket, CreateInteractionDto dto)
        {
            var interaction = new Interaction
            {
                Message = dto.Message,
                Author = dto.Author
            };
            interaction.CreatedDate = DateTime.Now;
            return await _context.AddInteractionAsync(ticket, interaction);
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            var ticket = await _context.GetByIdAsync(id);
            return ticket;
        }

        public async Task<List<Ticket>> GetAllAsync(string status, string priority, string categoryId)
        {

            throw new NotImplementedException();
        }
    }
}