using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base
        (options)
        {
        }

        //Todo:implement DbSets for each entity on Models/Entities
    }
}