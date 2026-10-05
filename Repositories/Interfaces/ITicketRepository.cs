
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Models.DTOs;

namespace DeskFlow.API.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> CreateTicketAsync(Ticket newTicket);
        Task<Ticket> UpdateTicketAsync(Ticket ticket);
        Task<Ticket> AddInteractionAsync(Ticket ticket, Interaction interaction);
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync(QueryFilterDto filter);
        Task<Ticket> GetByIdForInteractionsAsync(int id);
        Task<bool> ValidCategoryId(int id);
    }
}