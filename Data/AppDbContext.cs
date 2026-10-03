using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace DeskFlow.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base
        (options)
        {
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Interaction> Interactions => Set<Interaction>();

    }
}