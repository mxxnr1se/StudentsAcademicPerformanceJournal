using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services.Interfaces
{
    public interface IStudentService : IService<StudentDTO>
    {
        Task<IEnumerable<StudentDTO>> GetAllByGroupIdAsync(int groupId);
    }
}