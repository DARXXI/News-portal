namespace AdminPanel.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public List<string> Author { get; set; } = new List<string>();
        public int Views { get; set; }
    }
}
