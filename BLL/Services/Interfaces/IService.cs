using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services.Interfaces
{
    public interface IService<T> where T : BaseEntityDTO
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T t);
        void Update(T t);
        void Remove(int id);
    }
}