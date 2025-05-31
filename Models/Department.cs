using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HU_HDP.Models
{
    public class Department
    {
        [Key]

        public int DepartmentId { get; set; }
        public int AcademicUnitId { get; set; }

        public string DepartmentName { get; set; }
        public string DepartmentAcronym { get; set; }


        [ForeignKey("AcademicUnitId")]
        public AcademicUnit AcademicUnit{get; set;}

        public ICollection<Trainee> Trainees { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
    }

  
}
