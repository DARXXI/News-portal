using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdminPanel.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Note { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        [JsonIgnore]
        public int? RoleId { get; set; }

        [Column(TypeName = "json")]
        public Role? Role { get; set; }

        [JsonIgnore]
        public List<int>? ProjectsId { get; set; } = new List<int>();

        [Column(TypeName = "json")]
        public ICollection<UserProject>? UserProjects { get; set; } = new List<UserProject>();

        [NotMapped]
        public string? ProjectsNames
        {
            get
            {
                return string.Join(" ", UserProjects.Select(t => t.Project.Name));
            }
        }

        [JsonIgnore]
        public int ImageId { get; set; }



        [Column(TypeName = "json")]
        public ICollection<Message>? Messages { get; set; } = new List<Message>();

    }
}
