namespace Domain.DTOs
{
    public class CreateAuctionDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal Price { get; set; }
        public int UserId { get; set; }

    }
}
