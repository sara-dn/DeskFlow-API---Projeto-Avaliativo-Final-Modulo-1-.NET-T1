using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskFlow.API.Models.DTOs
{
    public class CreateInteractionDto
    {
        public string Author {get; set;}
        public string Message {get; set;}
    }
}