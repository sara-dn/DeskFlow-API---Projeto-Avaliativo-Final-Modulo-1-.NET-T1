using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.API.Models.Entities
{
    public class Category
    {
        public int Id {get; set;}
        public string Name {get; set;}
    }
}