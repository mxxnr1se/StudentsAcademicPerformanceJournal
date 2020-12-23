using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class RatingDTO : BaseEntityDTO
    {
        [Required]
        public int StudentId { get; set; }
        
        [Required]
        public int SubjectId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Score { get; set; }
    }
}