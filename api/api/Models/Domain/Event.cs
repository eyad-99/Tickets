using System.Text.Json.Serialization;

namespace api.Models.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public  int NumberOfTickets { get; set; }
        public int RemainTickets { get; set; }

        public double Price { get; set; }


        [JsonIgnore] // Add this attribute to prevent serialization of the User property
        public User User { get; set; }
    }
}
