using Microsoft.AspNetCore.Identity;

namespace api.Models.Domain
{
    public class User:IdentityUser
    {
        public List<Event>? Events { get; set; }
        public List<Ticket>? Tickets { get; set; }

    }
}
