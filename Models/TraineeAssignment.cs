using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HU_HDP.Models
{
    public class TraineeAssignment
    {
        [Key]
        public  int TraineeAssignmentId { get; set; }

       
        public required int TraineeId { get; set; }

      
        public required int CenterId { get; set; }

        
        public DateTime AssignedDate { get; set; }

         
        public required string EntryYear { get; set; } // e.g. 2024/25

        
        public required string Status { get; set; } // e.g. Active, Inactive

        [ForeignKey("TraineeId")]
        public required Trainee Trainee { get; set; }

        [ForeignKey("CenterId")]
        public required Center Center { get; set; }
    }
}