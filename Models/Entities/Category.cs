using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DeskFlow.API.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        public ICollection<Ticket> Tickets {get; set;}

        public void Update(Category category)
        {
            Name = category.Name;
        }
    }
}