using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BLL.Services.Realizations
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _uow.Students.GetAllAsync();

            var ratings = await _uow.Ratings.GetAllAsync();

            foreach (var student in students)
            {
                var scoresum = 0m;
                var count = 0;

                foreach (var rating in ratings)
                {
                    if (rating.StudentId == student.Id)
                    {
                        scoresum += rating.Score;
                        count++;
                    }
                }

                student.AvgScore = scoresum / count;
            }

            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _uow.Students.GetByIdAsync(id);

            if (student == null)
                throw new DbResultException("Db query result to students is null");

            var ratings = await _uow.Ratings.GetAllAsync();

            var scoresum = 0m;
            var count = 0;

            foreach (var rating in ratings)
            {
                if (rating.StudentId == student.Id)
                {
                    scoresum += rating.Score;
                    count++;
                }
            }

            student.AvgScore = scoresum / count;

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> CreateAsync(StudentDTO studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);

            if (studentDTO.GroupId != null && (await _uow.Groups.GetByIdAsync((int) studentDTO.GroupId)) == null)
                throw new DbResultException("The group with current GroupId doesn't exist");

            await _uow.Students.CreateAsync(student);
            if (!await _uow.SaveChangesAsync())
                throw new DbResultException("Changes to students weren't produced");

            return _mapper.Map<StudentDTO>(student);
        }

        public void Update(StudentDTO studentDTO)
        {
            var student = _uow.Students.GetByIdAsync(studentDTO.Id).Result;

            if (student == null)
                throw new DbResultException("There isn't such student in db");

            student = _mapper.Map<Student>(studentDTO);

            _uow.Students.Update(student);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbResultException("Changes to students weren't produced");
        }

        public void Remove(int id)
        {
            var student = _uow.Students.GetByIdAsync(id).Result;

            if (student == null)
                throw new DbResultException("No record to remove from students");

            _uow.Students.Remove(student);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbResultException("Changes to students weren't produced");
        }

        public async Task<IEnumerable<StudentDTO>> GetAllByGroupIdAsync(int groupId)
        {
            var students = await _uow.Students.GetAllAsync();

            var studentsByGroupId = students.Where(s => s.GroupId == groupId);

            if (studentsByGroupId == null)
                throw new DbResultException("Db query result to students is null");

            var ratings = await _uow.Ratings.GetAllAsync();

            foreach (var student in studentsByGroupId)
            {
                var scoresum = 0m;
                var count = 0;

                foreach (var rating in ratings)
                {
                    if (rating.StudentId == student.Id)
                    {
                        scoresum += rating.Score;
                        count++;
                    }
                }

                student.AvgScore = scoresum / count;
            }

            return _mapper.Map<IEnumerable<StudentDTO>>(studentsByGroupId);
        }
    }
}