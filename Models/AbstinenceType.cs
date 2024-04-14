using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1Theres.Models
{
    public class AbstinenceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AbstinenceId { get; set; }
        [Required(ErrorMessage ="You need to write a name for leave of abstinence")]
        public string AbstinenceName { get; set; }
        public IList<AbstinenceList>? AbstinenceLists { get; set; }
    }
}
