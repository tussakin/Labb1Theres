using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1Theres.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="You need to add a name to the employee")]
        public string EmployeeName { get; set; }
        public IList<AbstinenceList>? AbstinenceLists { get; set; }

    }
}
