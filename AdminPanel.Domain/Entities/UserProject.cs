using System.Text.Json.Serialization;

namespace AdminPanel.Domain.Entities
{
    public class UserProject
    {
        [JsonIgnore]
        public int ProjectId { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public Project Project { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
