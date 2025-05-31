using System.ComponentModel.DataAnnotations;

namespace HU_HDP.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        public string MainTopic { get; set; }
        public string SubTopic { get; set; }
        public string Description { get; set; }

        public ICollection<WeeklySchedule> WeeklySchedules { get; set; }
    }
}