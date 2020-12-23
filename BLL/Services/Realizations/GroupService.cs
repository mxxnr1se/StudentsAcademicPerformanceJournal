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
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GroupService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupDTO>> GetAllAsync()
        {
            var groups = await _uow.Groups.GetAllAsync();

            return _mapper.Map<IEnumerable<GroupDTO>>(groups);
        }

        public async Task<GroupDTO> GetByIdAsync(int id)
        {
            var group = await _uow.Groups.GetByIdAsync(id);

            if (group == null)
                throw new DbResultException("Db query result to groups is null");

            return _mapper.Map<GroupDTO>(group);
        }

        public async Task<GroupDTO> CreateAsync(GroupDTO groupDTO)
        {
            var group = _mapper.Map<Group>(groupDTO);

            await _uow.Groups.CreateAsync(group);
            if (!await _uow.SaveChangesAsync())
                throw new DbResultException("Changes to groups weren't produced");

            return _mapper.Map<GroupDTO>(group);
        }

        public void Update(GroupDTO groupDTO)
        {
            var group = _uow.Groups.GetByIdAsync(groupDTO.Id).Result;

            if (group == null)
                throw new DbResultException("There isn't such group in db");

            group = _mapper.Map<Group>(groupDTO);

            _uow.Groups.Update(group);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbResultException("Changes to groups weren't produced");
        }

        public void Remove(int id)
        {
            var group = _uow.Groups.GetByIdAsync(id).Result;

            if (group == null)
                throw new DbResultException("No record to remove from groups");

            _uow.Groups.Remove(group);
            if (!_uow.SaveChangesAsync().Result)
                throw new DbResultException("Changes to groups weren't produced");
        }
    }
}