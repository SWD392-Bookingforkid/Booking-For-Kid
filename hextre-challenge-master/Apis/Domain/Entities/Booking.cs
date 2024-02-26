using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
	public class Booking : BaseEntity
	{
		public Guid GuestID { get; set; }
		public Guid PartyID { get; set; }
		public string Request { get; set; }
		public string Response { get; set; }
		public bool Status { get; set; }
		public virtual Party? Party { get; set; }
		public virtual User? Guest { get; set; }
	}
}
