namespace JoinTheWrite.Models.Dto
{
    public class CreationDto
    {
        public Guid CreationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int ChapterCount { get; set; }
    }
}
