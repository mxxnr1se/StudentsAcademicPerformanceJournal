using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities;

namespace BLL.DTOs
{
    public class StudentDTO : BaseEntityDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        public int? GroupId { get; set; }
        public string GroupNumber { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal AvgScore { get; set; }
    }
}