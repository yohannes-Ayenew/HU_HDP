using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HU_HDP.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public required string FirstName  { get; set; }

        [Required, MaxLength(50)]
        public required string MiddleName { get; set; }

        [Required, MaxLength(50)]
        public required string LastName { get; set; }

        [Required, MaxLength(50)]
        public required string AcademicRank { get; set; }

        [ForeignKey("DepartmentId")]
        public required Department Department { get; set; }

        [ForeignKey("UserId")]
        public required User User { get; set; }

        public required ICollection<WeeklySchedule> WeeklySchedules { get; set; }
        public required ICollection<Attendance> Attendances { get; set; }
    }
}