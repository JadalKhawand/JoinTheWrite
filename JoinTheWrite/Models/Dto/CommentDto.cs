using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models.Dto
{
    public class CommentDto
    {
        [Key]
        public Guid CommentId { get; set; }
        public Guid CreationId { get; set; }  
        public Creation? Creation { get; set; }  
        public string Content { get; set; } = string.Empty;
    }
}
