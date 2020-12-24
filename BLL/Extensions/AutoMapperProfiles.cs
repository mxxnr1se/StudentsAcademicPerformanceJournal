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
            CreateMap<Rating, RatingDTO>()
                    .ForMember(dest => dest.StudentFirstName,
                               options => options.MapFrom(
                                       source => source.Student.FirstName))
                    .ForMember(dest => dest.StudentLastName,
                               options => options.MapFrom(
                                       source => source.Student.LastName))
                    .ForMember(dest => dest.SubjectTitle,
                               options => options.MapFrom(
                                       source => source.Subject.Title));
            CreateMap<RatingDTO, Rating>();
            CreateMap<Student, StudentDTO>()
                    .ForMember(dest => dest.GroupNumber,
                               options => options.MapFrom(source => source.Group.Number));
            CreateMap<StudentDTO, Student>();
            

            
            
        }
    }
}