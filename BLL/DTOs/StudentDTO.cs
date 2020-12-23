using System.ComponentModel.DataAnnotations;
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

        public decimal AvgScore { get; set; }
    }
}