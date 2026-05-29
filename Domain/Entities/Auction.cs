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
        public string ImageUrl { get; set; }
        public bool IsOpen => EndDate > DateTime.Now;
        public bool IsActive { get; set; } = true;
        public ICollection<Bid> Bids { get; set; }
    }
}

