using System.ComponentModel.DataAnnotations;

namespace DeskFlow.API.Models.DTOs
{
    public class CreateInteractionDto
    {
        [Required]
        public string Author {get; set;}
        [Required]
        public string Message {get; set;}
    }
}