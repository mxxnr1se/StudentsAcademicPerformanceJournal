using System;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context, IGroupRepository groupRepository, IStudentRepository studentRepository,
                     ISubjectRepository subjectRepository, IRatingRepository ratingRepository)
        {
            _context = context;
            Groups = groupRepository;
            Students = studentRepository;
            Subjects = subjectRepository;
            Ratings = ratingRepository;
        }
       
        public IGroupRepository Groups { get; }
        public IStudentRepository Students { get; }
        public ISubjectRepository Subjects { get; }
        public IRatingRepository Ratings { get; }
       
        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}