using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskFlow.API.Models.Entities;
using DeskFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DeskFlow.API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            await _context.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task StartTicketAsync(int id)
        {
            
            throw new NotImplementedException();
        }

        public async Task<Ticket> CloseTicketAsync(int id, string resolution)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> AddInteractionAsync(int id, Interaction interaction)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllAsync(string status, string priority, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}