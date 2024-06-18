using System.ComponentModel.DataAnnotations;

namespace api.Models.DTO
{
    public class EventCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfTickets { get; set; }
        public double Price { get; set; }
    }
}
