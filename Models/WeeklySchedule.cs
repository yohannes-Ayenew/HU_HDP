using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HU_HDP.Models
{
    public class WeeklySchedule
    {
        [Key]
        public int WeeklyScheduleId { get; set; }
        public int TrainerId { get; set; }
        public int CenterId { get; set; }
        public int RoomId { get; set; }
        public int TopicId { get; set; }

        public string WeekName { get; set; }
        public string TrainingDay { get; set; }
        public DateTime TrainingDate { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }


        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }
        [ForeignKey("CenterId")]
        public Center Center { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        public ICollection<Attendance> Attendances { get; set; }


    }

}