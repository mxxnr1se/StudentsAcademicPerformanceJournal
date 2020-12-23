using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Realizations
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Subject> DbSetWithAllProperties()
        {
            return DbSet;
        }
    }
}