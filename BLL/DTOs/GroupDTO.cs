using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs
{
    public class GroupDTO : BaseEntityDTO
    {
        [Required(ErrorMessage = "Group number is required"), StringLength(10)]
        public string Number { get; set; }
    }
}