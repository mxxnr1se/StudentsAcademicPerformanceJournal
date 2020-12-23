using BLL.Services.Interfaces;
using BLL.Services.Realizations;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configurations.Dependencies
{
    public static class BLLDependencies
    {
        public static void BLLDependenciesResolver(this IServiceCollection services)
        {
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IRatingService, RatingService>();
        }
    }
}