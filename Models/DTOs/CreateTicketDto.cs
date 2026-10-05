using System.ComponentModel.DataAnnotations;

namespace DeskFlow.API.Models.DTOs
{
    public class CreateTicketDto
    {
        [Required]
        public string Title {get; set;}
        public string Description {get; set;}
        public string RequesterName {get; set;}
        [Required]
        [AllowedValues("low", "medium", "high", ErrorMessage = "Value must be 'low', 'medium', or 'high'.")]
        public string Priority {get; set;}
        public int CategoryId {get; set;}
    }
}