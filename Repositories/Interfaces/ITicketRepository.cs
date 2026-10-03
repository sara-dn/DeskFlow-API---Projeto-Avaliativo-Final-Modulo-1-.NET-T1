using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> CreateTicketAsync(Ticket newTicket);
        Task<Ticket> UpdateTicketAsync(Ticket ticket);
        Task<Ticket> AddInteractionAsync(Ticket ticket, Interaction interaction);
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync(string status, string priority, string categoryId);
    }
}