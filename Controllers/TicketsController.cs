using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DeskFlow.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeskFlow.API.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> NewAsync([FromBody]Ticket ticket)
        {
            //todo: implement writing logic using services
            return Created("/tickets", ticket);  
        }

        [HttpPatch]
        [Route("{id}/start")]
        public async Task<IActionResult> StartAsync([FromRoute]int id, [FromBody] Ticket ticket)
        {
            //todo: implement start logic
            return Ok();
        }

        [HttpPatch]
        [Route("{id}/close")]
        public async Task<IActionResult> CloseAsync([FromRoute]int id, [FromBody] Ticket ticket)
        {
            //todo: implement close logic
            return Ok();
        }

        [HttpPost]
        [Route("{id}/interactions")]
        public async Task<IActionResult> NewAsync([FromRoute]int id, [FromBody]Interection interection)
        {
            //todo: implement writing logic using services
            return Created("/tickets/{id}/interactions", interection);  
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ByIdAsync([FromRoute]int id)
        {
            Category tickets = new();
            return Ok(tickets);
        }

        [HttpGet]
        public async Task<IActionResult> AllAsync()
        {
            List<Ticket> tickets = new();
            return Ok(tickets);
        }
    }
}