using api.Data;
using api.Models.Domain;
using api.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.impl
{
    public class EventRepository:IEventRepository
    {
        private readonly AuthDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public EventRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<Event> CreateEventAsync(Event eventObj)
        {
            _context.Events.Add(eventObj);
            await _context.SaveChangesAsync();
            return eventObj;
        }

        public async Task<Event> UpdateEventAsync(Event eventObj)
        {
            _context.Entry(eventObj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return eventObj;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventObj = await _context.Events.FindAsync(id);
            if (eventObj == null)
            {
                return false;
            }

            _context.Events.Remove(eventObj);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
