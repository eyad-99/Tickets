using api.Models.Domain;

namespace api.Repository.interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task<Event> CreateEventAsync(Event eventObj);
        Task<Event> UpdateEventAsync(Event eventObj);
        Task<bool> DeleteEventAsync(int id);
    }
}
