using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HU_HDP.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public required ICollection<UserRole> UserRole { get; set; }
    }
}
