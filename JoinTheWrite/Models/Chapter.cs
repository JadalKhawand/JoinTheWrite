using JoinTheWrite.Models.enums;
using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models
{
    public class Chapter
    {
        [Key]
        public Guid ChapterId { get; set; }
        public Guid CreationId { get; set; }
        public Creation? Creation { get; set; }
        public int ChapterNumber { get; set; }
        public Guid? FinalizedContributionId { get; set; }
        public WritingStatus Status { get; set; } = WritingStatus.OpenForWriting;
        public DateTime? VotingDeadline { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();
    }
}
