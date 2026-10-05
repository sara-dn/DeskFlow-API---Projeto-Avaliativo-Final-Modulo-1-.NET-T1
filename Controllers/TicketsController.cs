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
            return Created("api/tickets", createdTicket);//201 Created
        }

        [HttpPatch("{id}/start")]
        public async Task<IActionResult> StartAsync([FromRoute] int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null && ticket.Status != "Open")
            {
                return BadRequest();//400 not found
            }
            await _ticketService.StartTicketAsync(ticket);
            return Ok();//200 OK
        }

        [HttpPatch("{id}/close")]
        public async Task<IActionResult> CloseAsync([FromRoute] int id, [FromBody] CloseTicketDto dto)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if(ticket == null && ticket.Status != "InProgress")
            {
                return BadRequest();
            }
            ticket = await _ticketService.CloseTicketAsync(ticket, dto);
            return Ok(ticket);
        }

        [HttpPost]
        [Route("{id}/interactions")]
        public async Task<IActionResult> AddInteractionAsync([FromRoute] int id, [FromBody] CreateInteractionDto dto)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if(ticket == null)
            {
                return NotFound();
            }
            var createdInteraction = await _ticketService.AddInteractionAsync(id, dto);
            
            return Created("api/tickets", createdInteraction);//201 Created Successfully
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string status, 
            [FromQuery] string priority, 
            [FromQuery] int categoryId)
        {
            var tickets = await _ticketService.GetAllAsync(status, priority, categoryId);
            if(tickets == null)
            {
                return NoContent();//204 nocontent
            }
            return Ok(tickets);
        }
    }
}