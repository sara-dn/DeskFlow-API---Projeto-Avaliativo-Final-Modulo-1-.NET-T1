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
        Task StartTicketAsync(int id);
        Task<Ticket> CloseTicketAsync(int id, string resolution);
        Task<Ticket> AddInteractionAsync(int id, Interaction interaction);
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync(string status, string priority, int categoryId);
    }
}