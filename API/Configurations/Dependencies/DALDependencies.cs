using DAL.Contexts;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Realizations;
using DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configurations.Dependencies
{
    public static class DALDependencies
    {
        public static void DALDependenciesResolver(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SAPContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<DbContext, SAPContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
        }
    }
}