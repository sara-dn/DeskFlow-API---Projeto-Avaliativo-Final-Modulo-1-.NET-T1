using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

//This is the "Chamados" from RF05
namespace DeskFlow.API.Models.Entities
{
    public class Ticket
    {
        [Key]
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string RequesterName {get; set;} //SolicitanteNome from RF05
        public DateTime OpenedDate {get; set;}
        public DateTime ClosedDate {get; set;}
        public string Solution {get; set;}
        public string Priority {get; set;} //low, medium, high
        public string Status {get; set;}//open, in progress, closed
        public int CategoryId {get; set;}
        public Category Category {get; set;}
        public ICollection<Interection> Interections {get; set;}
    }
}