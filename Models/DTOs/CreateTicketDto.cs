using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskFlow.API.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DeskFlow.API.Models.DTOs
{
    public class CreateTicketDto
    {
        [Required]
        public string Title {get; set;}
        public string Description {get; set;}
        public string RequesterName {get; set;}
        public DateTime OpenedDate {get; set;} = DateTime.Now;
        [Required]
        [AllowedValues("low", "medium", "high", ErrorMessage = "Value must be 'low', 'medium', or 'high'.")]
        public string Priority {get; set;}
        public string Status {get; set;} = "open";
        public int CategoryId {get; set;}
    }
}