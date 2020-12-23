using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWorks;

namespace BLL.Services.Realizations
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SubjectService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDTO>> GetAllAsync()
        {
            var subjects = await _uow.Subjects.GetAllAsync();

            return _mapper.Map<IEnumerable<SubjectDTO>>(subjects);
        }

        public async Task<SubjectDTO> GetByIdAsync(int id)
        {
            var subject = await _uow.Subjects.GetByIdAsync(id);

            if (subject == null)
                throw new DbResultException("Db query result to subjects is null");

            return _mapper.Map<SubjectDTO>(subject);
        }

        public async Task<SubjectDTO> CreateAsync(SubjectDTO subjectDTO)
        {
            var subject = _mapper.Map<Subject>(subjectDTO);

            await _uow.Subjects.CreateAsync(subject);
            if (!await _uow.SaveChangesAsync())
                throw new DbResultException("Changes to subjects weren't produced");

            return _mapper.Map<SubjectDTO>(subject);
        }

        public void Update(SubjectDTO subjectDTO)
        {
            var subject = _uow.Subjects.GetByIdAsync(subjectDTO.Id).Result;

            if (subject == null)
                throw new DbResultException("There isn't such subject in db");

            subject = _mapper.Map<Subject>(subjectDTO);

            _uow.Subjects.Update(subject);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbResultException("Changes to subjects weren't produced");
        }

        public void Remove(int id)
        {
            var subject = _uow.Subjects.GetByIdAsync(id).Result;

            if (subject == null)
                throw new DbResultException("No record to remove from subjects");

            _uow.Subjects.Remove(subject);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbResultException("Changes to subjects weren't produced");
        }
    }
}