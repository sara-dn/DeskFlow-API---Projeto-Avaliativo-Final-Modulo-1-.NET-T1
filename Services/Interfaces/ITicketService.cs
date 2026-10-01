using DeskFlow.API.Models.DTOs;
using DeskFlow.API.Models.Entities;

namespace DeskFlow.API.Services.Interfaces
{
    public interface ITicketService
    {
        Task<Ticket> CreateTicketAsync(CreateTicketDto dto);
        Task<Ticket> StartTicketAsync(int id);
        Task<Ticket> CloseTicketAsync(int id, CloseTicketDto dto);
        Task<Ticket> AddInteractionAsync(int id, CreateInteractionDto dto);
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync( string status, string priority, int categoryId);

    }
}