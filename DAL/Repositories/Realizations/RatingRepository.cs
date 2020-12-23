using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Realizations
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Rating> DbSetWithAllProperties()
        {
            return DbSet.Include(s => s.Student)
                        .Include(s => s.Subject);
        }
    }
}