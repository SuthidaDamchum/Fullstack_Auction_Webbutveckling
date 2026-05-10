using Data.Entities;

namespace Domain.DTOs
{
    public class AuctionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User CreatedBy { get; set; } = null!;
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Computed property, sparas ej i databasen
        public bool IsOpen => DateTime.UtcNow < EndDate;
    }
}
