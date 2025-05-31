using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HU_HDP.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        // Foreign Key to User
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        // Foreign Key to Role
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
