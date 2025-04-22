using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        public Guid ContributionId { get; set; }
        public Contribution? Contribution { get; set; }
        public Guid AuthorId { get; set; }
        public User? Author { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
        
    }
}
