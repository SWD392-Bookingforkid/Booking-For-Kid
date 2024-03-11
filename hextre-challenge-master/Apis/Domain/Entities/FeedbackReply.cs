using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class FeedbackReply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? ReplyContent { get; set; }
        public Guid HostID { get; set; }
        public Guid FeedbackID { get; set; }
        public virtual User? Host { get; set; }
        public virtual Feedback? Feedback { get; set; }
    }
}