namespace JoinTheWrite.Models.Dto
{
    public class AddContributionDto
    {
        public Guid ChapterId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
