using Domain.DTOs;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }

        public ICollection<Auction> Auctions { get; set; }

      
    }
}

