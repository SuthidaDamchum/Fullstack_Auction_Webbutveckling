namespace Domain.DTOs
{
    public class BidDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }
    }
}
