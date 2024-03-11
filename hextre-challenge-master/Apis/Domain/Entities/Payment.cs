using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public decimal AmountMoney { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public bool isDeposit { get; set; }
        public Guid BookingID { get; set; }
        public virtual Booking? Booking { get; set; }
    }
}