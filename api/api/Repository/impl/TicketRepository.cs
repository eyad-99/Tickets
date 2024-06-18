using api.Data;
using api.Models.Domain;
using api.Repository.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.impl
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<User> _userManager;

        public TicketRepository(AuthDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(string userId)
        {
            return await _context.Tickets
                .Where(t => t.UserId == userId)
                .Include(t => t.Event)
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }


        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
        public async Task<IEnumerable<Event>> GetEventsNotAssignedToUserAsync(string userId)
        {
            return await _context.Events
                .Where(e => !_context.Tickets.Any(t => t.EventId == e.Id && t.UserId == userId))
                .ToListAsync();
        }

        public async Task<Ticket> UpdateTicketAsync(Ticket ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return false;
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
