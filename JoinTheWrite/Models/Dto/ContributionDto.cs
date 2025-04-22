using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models.Dto
{
    public class ContributionDto
    {
        public Guid ChapterId { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;

    }
}
