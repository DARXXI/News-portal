using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Domain.Entities
{
    public class Register : BaseEntity
    {
        public string Name { get; set; } = new String("");

        public string Email { get; set; } = new String("");

        [DataType(DataType.Password)]
        public string Password { get; set; } = new String("");

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; } = new String("");

        [Column(TypeName = "json")]
        public Role? Role { get; set; }

    }
}
