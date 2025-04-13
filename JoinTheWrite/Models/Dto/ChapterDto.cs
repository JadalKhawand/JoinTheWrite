using JoinTheWrite.Models.enums;

namespace JoinTheWrite.Models.Dto
{
    public class ChapterDto
    {
        public WritingStatus Status { get; set; }
        public DateTime? VotingDeadline { get; set; }
        public string? FinalizedContent { get; set; }
    }
}
