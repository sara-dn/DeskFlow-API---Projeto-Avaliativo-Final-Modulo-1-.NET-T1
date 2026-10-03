using Microsoft.AspNetCore.Mvc;
using DeskFlow.API.Services.Interfaces; 
using DeskFlow.API.Models.DTOs;

namespace DeskFlow.API.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTicketDto dto)
        {
            var createdTicket = await _ticketService.CreateTicketAsync(dto);
        
            return Created();
        }

        [HttpPatch("{id}/start")]
        public async Task<IActionResult> StartAsync([FromRoute] int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound(new { message = $"Ticket with ID {id} not found." });
            }
            await _ticketService.StartTicketAsync(ticket);
            return Created();
        }

        [HttpPatch("{id}/close")]
        public async Task<IActionResult> CloseAsync([FromRoute] int id, [FromBody] CloseTicketDto dto)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if(ticket == null)
            {
                return NotFound(new { message = $"Ticket with ID {id} not found." });
            }
            await _ticketService.CloseTicketAsync(ticket, dto);
            return NoContent();
        }

        [HttpPost("{id}/interactions")]
        public async Task<IActionResult> AddInteractionAsync([FromRoute] int id, [FromBody] CreateInteractionDto dto)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if(ticket == null)
            {
                return NotFound(new { message = $"Ticket with ID {id} not found." });
            }
            var createdInteraction = await _ticketService.AddInteractionAsync(ticket, dto);
            
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            
            if (ticket == null)
                return NotFound(new { message = $"Ticket with ID {id} not found." });

            return Ok(ticket);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string status, 
            [FromQuery] string priority, 
            [FromQuery] string categoryId)
        {
            var tickets = await _ticketService.GetAllAsync(status, priority, categoryId);
            return Ok(tickets);
        }
    }
}