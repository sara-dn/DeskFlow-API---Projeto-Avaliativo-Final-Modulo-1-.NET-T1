using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DeskFlow.API.Models.Entities
{
    public class Interection
    {
        public int Id {get; set;}
        public int TicketId {get; set;}
        public string Author {get; set;}
        public string Message {get; set;}
        public DateTime CreatedDate {get; set;} //DataRegistro from RF09
    }
}