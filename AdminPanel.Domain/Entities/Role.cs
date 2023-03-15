using System.Text.Json.Serialization;

namespace AdminPanel.Domain.Entities
{
    public  class Role : BaseEntity
    {
        public string Name { get; set;}
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
