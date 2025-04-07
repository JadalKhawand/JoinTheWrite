using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models.Dto
{
    public class ContributionDto
    {
        [Key]
        public Guid ContributionId { get; set; }
        public Guid ChapterId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; }
        public string AuthorUsername { get; set; } = string.Empty;
        public int VoteCount { get; set; }
    }
}
