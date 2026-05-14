using Data.Entities;

namespace Domain.Entities
{
    public class Auction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User CreatedBy { get; set; } = null!;
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsOpen { get; set; }
    }
}

