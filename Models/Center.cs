using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HU_HDP.Models
{
    public class Center
    {
        [Key]
        public int CenterId { get; set; }
        public int CenterCode { get; set; }
        public string CenterName { get; set; }
        public string Status { get; set; }


        public ICollection<WeeklySchedule> WeeklySchedules { get; set; }
        public ICollection<TraineeAssignment> TraineeAssignmnets { get; set; }
    }
}
