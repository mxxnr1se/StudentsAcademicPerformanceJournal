using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class RatingDTO : BaseEntityDTO
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        public int SubjectId { get; set; }
        public string SubjectTitle { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Score { get; set; }
    }
}