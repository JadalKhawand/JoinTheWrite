using JoinTheWrite.Models.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoinTheWrite.Models
{
    public class Chapter
    {
        [Key]
        public Guid ChapterId { get; set; }

        [Required]
        public Guid CreationId { get; set; }  

        public Creation Creation { get; set; } 

        public int ChapterNumber { get; set; }

        public Guid? FinalizedContributionId { get; set; }  

        public Contribution? FinalizedContribution { get; set; }

        public string FinalizedTitle { get; set; } = string.Empty;

        public WritingStatus Status { get; set; } = WritingStatus.OpenForWriting;

        public DateTime? VotingDeadline { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();
    }
}
