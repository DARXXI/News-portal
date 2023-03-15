using System.Text.Json.Serialization;

namespace AdminPanel.Domain.Entities
{
    public class Project: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<UserProject> ProjectUsers { get; set; }
    }
}
