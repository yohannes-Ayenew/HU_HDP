using System.ComponentModel.DataAnnotations;

namespace HU_HDP.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public required ICollection<Trainee> Trainees { get; set; }
        public required ICollection<Trainer> Trainers { get; set; }
    }
}
