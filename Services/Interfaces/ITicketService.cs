using DeskFlow.API.Models.DTOs;
using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Services.Interfaces
{
    public interface ITicketService
    {
        Task<Ticket> CreateTicketAsync(CreateTicketDto dto);
        Task<Ticket> StartTicketAsync(Ticket ticket);
        Task<Ticket> CloseTicketAsync(Ticket ticket, CloseTicketDto dto);
        Task<Ticket> AddInteractionAsync(Ticket ticket, CreateInteractionDto dto);
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync( string status, string priority, string categoryId);

    }
}