using api.Models.Domain;

namespace api.Repository.interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
         Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(string userId);
         Task<IEnumerable<Event>> GetEventsNotAssignedToUserAsync(string userId);

        Task<Ticket> GetTicketByIdAsync(int id);
        Task<Ticket> CreateTicketAsync(Ticket TicketObj);
        Task<Ticket> UpdateTicketAsync(Ticket TicketObj);
        Task<bool> DeleteTicketAsync(int id);
    }
}
