using System.ComponentModel.DataAnnotations;

namespace DeskFlow.API.Models.DTOs
{
    public class CloseTicketDto
    {
        [Required]
        public string Solution {get; set;}
    }
}