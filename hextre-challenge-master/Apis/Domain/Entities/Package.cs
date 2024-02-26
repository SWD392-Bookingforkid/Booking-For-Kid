using System;
namespace Domain.Entities
{
	public class Package : BaseEntity
	{
		public string? Name { get; set; }
		public string? Detail { get; set; }
		public decimal Price { get; set; }
	}
}

