using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HU_HDP.Models
{
    public class ActionResearch
    {
        [Key]
        public int ActionResearchId { get; set; }


        public string? ActionResearchTitle { get; set; }  

        public string? AcademicYear { get; set; } // e.g. 2024/25

        public string? Status { get; set; } // e.g. Submitted, Approved, Rejected

        public int? TraineeId { get; set; }

        [ForeignKey("TraineeId")]
        public Trainee? Trainee { get; set; }
    }
}