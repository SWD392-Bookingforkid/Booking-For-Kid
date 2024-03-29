﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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
        public virtual Feedback? Feedback { get; set; }
        public virtual FeedbackReply? FeedbackReply { get; set; }
    }
}
