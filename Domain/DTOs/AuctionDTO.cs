using Domain.Entities;

namespace Domain.DTOs
{
    public class AuctionDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsOpen => EndDate > DateTime.Now;
        public bool IsActive { get; set; } = true;
        public ICollection<Bid> Bids { get; set; }
    }
}
