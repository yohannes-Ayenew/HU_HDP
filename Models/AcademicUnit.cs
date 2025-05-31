using System.ComponentModel.DataAnnotations;
namespace HU_HDP.Models
{
    public class AcademicUnit
    {
        [Key]
        public int AcademicUnitId { get; set; }
        public string AcademicUnitType { get; set; }
        public string AcademicUnitName { get; set; }
        public string AcademicUnitAcronym { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}