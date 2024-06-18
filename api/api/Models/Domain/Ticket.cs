using System.Text.Json.Serialization;

namespace api.Models.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
       public Event Event { get; set; }
        public int EventId { get; set; }

        public DateTime ReserveDate { get; set; }
        [JsonIgnore]

        public User User { get; set; }
        public string UserId { get; set; }  // Add this property


    }
}
