using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HU_HDP.Models
{
    public class Trainee
    {
        [Key]
        public int TraineeId { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }

        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string AcademicRank { get; set; }
        public required bool InductionTaken { get; set; }
        public required int EntryYear { get; set; }
        // public required string Status { get; set; } // Promoted, InProgress, Dropout, Graduated
        public Status Status { get; set; }

        [ForeignKey("DepartmentId")]
        public required Department Department { get; set; }

        [ForeignKey("UserId")]
        public required User User { get; set; }

        public required ICollection<TraineeAssignment> TraineeAssignments { get; set; }
        public required ICollection<Attendance> Attendances { get; set; }
        public required ICollection<ActionResearch> ActionResearches { get; set; }


    }
    public enum Status
    {
        Promoted,
        InProgress,
        Dropout,
        Graduated
    }
}
