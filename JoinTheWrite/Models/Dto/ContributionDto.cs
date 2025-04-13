using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models.Dto
{
    public class ContributionDto
    {
        public Guid ChapterId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string AuthorUsername { get; set; } = string.Empty;
    }
}
