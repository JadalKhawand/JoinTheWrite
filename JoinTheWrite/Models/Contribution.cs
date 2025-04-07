using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models
{
    public class Contribution
    {
        [Key]
        public Guid ContributionId { get; set; }
        public Guid ChapterId { get; set; }
        public Chapter? Chapter { get; set; }
        public Guid AuthorId { get; set; }
        public User? Author { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
