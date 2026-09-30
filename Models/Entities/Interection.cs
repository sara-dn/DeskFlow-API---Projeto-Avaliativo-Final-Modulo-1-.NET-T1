using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.API.Models.Entities
{
    public class Interection
    {
        [Key]
        public int Id {get; set;}
        public string Author {get; set;}
        public string Message {get; set;}
        public DateTime CreatedDate {get; set;} //DataRegistro from RF09
        public int TicketId {get; set;}
        public Ticket Ticket {get; set;}
    }
}