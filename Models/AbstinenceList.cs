using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1Theres.Models
{
    public class AbstinenceList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int FkEmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [Required]
        [ForeignKey("AbstinenceType")]
        public int FkAbstinenceType { get; set; }
        public AbstinenceType? AbstinenceType { get; set; }
        public DateTime AbstinenceStart { get; set; }
        public DateTime AbstinenceEnd { get; set; }


    }
}
