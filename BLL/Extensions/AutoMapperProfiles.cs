using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<Rating, RatingDTO>().ReverseMap();
            
            CreateMap<Student, StudentDTO>()
                    .ForMember(dest => dest.GroupNumber,
                               options => options.MapFrom(source => source.Group.Number));
            CreateMap<StudentDTO, Student>();
            

            
            
        }
    }
}