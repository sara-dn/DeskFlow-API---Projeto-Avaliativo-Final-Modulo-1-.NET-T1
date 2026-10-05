using DeskFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

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