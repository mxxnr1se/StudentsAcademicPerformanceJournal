using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services.Interfaces
{
    public interface IRatingService : IService<RatingDTO>
    {
        Task<IEnumerable<RatingDTO>> GetAllBySubjectIdAsync(int subjectId);
        Task<IEnumerable<RatingDTO>> GetAllByStudentIdAsync(int studentId);
        
    }
}