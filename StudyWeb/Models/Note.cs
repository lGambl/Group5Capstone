namespace StudyWeb.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";

        public int SourceId { get; set; }

        public string Owner { get; set; } = "";
    }
}
