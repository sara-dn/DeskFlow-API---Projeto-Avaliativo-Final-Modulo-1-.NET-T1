using System.ComponentModel.DataAnnotations;

namespace DeskFlow.API.Models.DTOs
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        public string Name { get; set; }        
    }
}