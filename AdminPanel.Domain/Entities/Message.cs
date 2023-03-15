using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdminPanel.Domain.Entities
{
    public class Message : BaseEntity
    {

        public int? UserId { get; set; }
        public User? User { get; set; }
        [JsonRequired]
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsRead { get; set; } 
    }
}
