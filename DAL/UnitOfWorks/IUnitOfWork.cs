using System;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGroupRepository Groups { get; }
        IStudentRepository Students { get; }
        ISubjectRepository Subjects { get; }
        IRatingRepository Ratings { get; }

        Task<bool> SaveChangesAsync();
    }
}