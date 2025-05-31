using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HU_HDP.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required, MaxLength(10)]
        public string? BuildingNumber { get; set; }

        [Required, MaxLength(10)]
        public string? FloorNumber { get; set; }

        [Required, MaxLength(20)]
        public string? RoomNumber { get; set; }

        public required ICollection<WeeklySchedule> WeeklySchedules { get; set; }
    }
}