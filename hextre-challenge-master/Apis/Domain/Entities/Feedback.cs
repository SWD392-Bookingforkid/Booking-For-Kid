using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public Guid CustomerID { get; set; }
        public Guid PartyID { get; set; }

        public virtual User? Customer { get; set; }
        public virtual Party? Party { get; set; }
        public virtual FeedbackReply? FeedbackReply { get; set; }

    }
}