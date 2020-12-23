using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// <c>GroupsController</c> is a class.
    /// Contains all http methods for working with groups.
    /// </summary>
    /// <remarks>
    /// This class can get, create, delete, edit groups.
    /// </remarks>

    // api/groups
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        /// <summary>
        /// This method returns all groups
        /// </summary>
        /// <response code="200">Returns all groups</response>

        //GET api/groups
        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _groupService.GetAllAsync();
            return Ok(groups);
        }

        /// <summary>
        /// This method returns group that has an inputted Id property
        /// </summary>
        /// <response code="200">Returns group that has an inputted Id property</response>
        /// <response code="404">Returns message that nothing was found, if message wasn't returned than id inputted incorrectly</response>

        //GET api/groups/{id}
        [HttpGet("{id:int}", Name = "GetGroupById")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            try
            {
                var group = await _groupService.GetByIdAsync(id);
                return Ok(group);
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method returns group that was created and path to it
        /// </summary>
        /// <response code="201">Returns group that was created and path to it</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message if something had gone wrong</response>

        //POST api/groups 
        [HttpPost]
        [ProducesResponseType(typeof(GroupDTO), 201)]
        public async Task<IActionResult> CreateBrand(GroupDTO groupDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (groupDTO.Id != 0)
                    return BadRequest("The Id should be empty");

                var createdGroup = await _groupService.CreateAsync(groupDTO);

                //Fetch the group from data source
                return CreatedAtRoute("GetGroupById", new {id = createdGroup.Id}, createdGroup);
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method changes group
        /// </summary>
        /// <response code="204">Returns nothing, group was successfully changed</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message that group was not found, if message wasn't returned than id inputted incorrectly</response>

        //PUT api/groups
        [HttpPut]
        [ProducesResponseType(204)]
        public IActionResult UpdateGroup(GroupDTO groupDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _groupService.Update(groupDTO);
                return NoContent();
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method deletes group
        /// </summary>
        /// <response code="204">Returns nothing, group was successfully deleted</response>
        /// <response code="404">Returns message that group was not found</response>

        //DELETE api/groups/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteGroup(int id)
        {
            try
            {
                _groupService.Remove(id);
                return NoContent();
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}