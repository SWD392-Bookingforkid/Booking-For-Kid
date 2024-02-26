using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Name { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public Guid RoleID { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Party>? Parties { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
