using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class SubjectDTO : BaseEntityDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
    }
}