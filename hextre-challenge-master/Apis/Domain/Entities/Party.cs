using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
	public class Party : BaseEntity
	{
		[ForeignKey("User")]
		public Guid HostID { get; set; }
		public Guid PackageID { get; set; }
		public Guid VenueID { get; set; }
		public bool Status { get; set; }
		public DateTime Date { get; set; }
		public string? Theme { get; set; }
		public string? Image { get; set; }
		public decimal DefaultCost { get; set; }
		public decimal AdditionalCost { get; set; }
		public decimal TotalPrice { get; set; }
		public virtual User Host { get; set; }
		//public virtual Booking Booking { get; set; }
		public virtual ICollection<Booking>? Bookings { get; set; }
		public virtual Package Package { get; set; }
		public virtual Venue Venue { get; set; }
	}
}
