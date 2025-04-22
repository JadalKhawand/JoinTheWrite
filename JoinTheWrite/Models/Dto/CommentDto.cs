using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models.Dto
{
    public class CommentDto
    {
        public Guid ContributionId { get; set; }
        public Guid AuthorId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
