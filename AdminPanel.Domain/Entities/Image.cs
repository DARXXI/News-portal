using System.Net.Mime;
using AdminPanel.Domain.Enums;

namespace AdminPanel.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string? Hash { get; set; }
        public  UsagePlace? UsagePlace { get; set; }
        public string? Path { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ContentType {get; set;}
    }
}
