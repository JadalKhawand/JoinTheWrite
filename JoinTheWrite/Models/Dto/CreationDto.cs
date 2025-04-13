namespace JoinTheWrite.Models.Dto
{
    public class CreationDto
    {
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int MaxChapters { get; set; }
        public int ChapterCount { get; set; }
    }
}
