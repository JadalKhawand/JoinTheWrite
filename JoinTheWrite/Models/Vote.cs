using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models
{
    public class Vote
    {
        [Key]
        public Guid VoteId { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid ContributionId { get; set; }
        public Contribution? Contribution { get; set; }

        public bool IsUpvote { get; set; }
    }
}
