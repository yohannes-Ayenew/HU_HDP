using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HU_HDP.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public int WeeklyScheduleId { get; set; }
        public int TraineeId { get; set; }
        public int TrainerId { get; set; }

        public required string Session { get; set; } // BTB, ATB
        public DateTime SubmissionDate { get; set; }
        public required string Status { get; set; } // Present, Absent


        [ForeignKey("WeeklyScheduleId")]
        public required WeeklySchedule WeeklySchedule { get; set; }
        [ForeignKey("TraineeId")]
        public required Trainee Trainee { get; set; }
        [ForeignKey("TrainerId")]
        public required Trainer Trainer { get; set; }
    }
}