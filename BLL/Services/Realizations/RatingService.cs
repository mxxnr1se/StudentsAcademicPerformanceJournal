using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWorks;

namespace BLL.Services.Realizations
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RatingService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RatingDTO>> GetAllAsync()
        {
            var ratings = await _uow.Ratings.GetAllAsync();

            return _mapper.Map<IEnumerable<RatingDTO>>(ratings);
        }

        public async Task<RatingDTO> GetByIdAsync(int id)
        {
            var rating = await _uow.Ratings.GetByIdAsync(id);

            if (rating == null)
                throw new DbResultException("Db query result to ratings is null");
            
            return _mapper.Map<RatingDTO>(rating);
        }

        public async Task<RatingDTO> CreateAsync(RatingDTO ratingDTO)
        {
            var rating = _mapper.Map<Rating>(ratingDTO);

            if ((await _uow.Students.GetByIdAsync((int)ratingDTO.StudentId)) == null)
                throw new DbResultException("Student with current StudentId doesn't exist");
            
            if ((await _uow.Subjects.GetByIdAsync((int)ratingDTO.SubjectId)) == null)
                throw new DbResultException("Subject with current SubjectId doesn't exist");
            
            await _uow.Ratings.CreateAsync(rating);
            if (!await _uow.SaveChangesAsync())
                throw new DbResultException("Changes to ratings weren't produced");

            return _mapper.Map<RatingDTO>(rating);
        }

        public void Update(RatingDTO ratingDTO)
        {
            var rating = _uow.Ratings.GetByIdAsync(ratingDTO.Id).Result;

            if (rating == null)
                throw new DbResultException("There isn't such rating in db");
            
            rating = _mapper.Map<Rating>(ratingDTO);

            _uow.Ratings.Update(rating);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbResultException("Changes to ratings weren't produced");
        }

        public void Remove(int id)
        {
            var rating = _uow.Ratings.GetByIdAsync(id).Result;

            if (rating == null)
                throw new DbResultException("No record to remove from ratings");

            _uow.Ratings.Remove(rating);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbResultException("Changes to ratings weren't produced");
        }

        public async Task<IEnumerable<RatingDTO>> GetAllBySubjectIdAsync(int subjectId)
        {
            var ratings =  await _uow.Ratings.GetAllAsync();

            var ratingsBySubjectId = ratings.Where(r => r.SubjectId == subjectId);
            
            return _mapper.Map<IEnumerable<RatingDTO>>(ratingsBySubjectId);
        }

        public async Task<IEnumerable<RatingDTO>> GetAllByStudentIdAsync(int studentId)
        {
            var ratings =  await _uow.Ratings.GetAllAsync();

            var ratingsByStudentId = ratings.Where(r => r.StudentId == studentId);
            
            return _mapper.Map<IEnumerable<RatingDTO>>(ratingsByStudentId);
        }
    }
}