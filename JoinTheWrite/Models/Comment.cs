using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        public Guid CreationId { get; set; }
        public Creation? Creation { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
        public Guid? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
    }
}
