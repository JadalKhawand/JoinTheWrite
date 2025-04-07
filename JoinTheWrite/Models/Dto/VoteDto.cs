namespace JoinTheWrite.Models.Dto
{
    public class VoteDto
    {
        public Guid ContributionId { get; set; }
        public bool IsUpvote { get; set; }
    }
}
