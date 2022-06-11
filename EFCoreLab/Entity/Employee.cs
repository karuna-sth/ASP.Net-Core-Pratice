using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreLab.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? EmployeeName { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string EmployeeAddress { get; set; } 
    }
}
