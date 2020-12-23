using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// <c>SubjectsController</c> is a class.
    /// Contains all http methods for working with subjects.
    /// </summary>
    /// <remarks>
    /// This class can get, create, delete, edit subject.
    /// </remarks>

    // api/subjects
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// This method returns all subjects
        /// </summary>
        /// <response code="200">Returns all subjects</response>

        //GET api/subjects
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllAsync();
            return Ok(subjects);
        }

        /// <summary>
        /// This method returns subject that has an inputted Id property
        /// </summary>
        /// <response code="200">Returns subject that has an inputted Id property</response>
        /// <response code="404">Returns message that nothing was found, if message wasn't returned than id inputted incorrectly</response>

        //GET api/subjects/{id}
        [HttpGet("{id:int}", Name = "GetSubjectById")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            try
            {
                var subject = await _subjectService.GetByIdAsync(id);
                return Ok(subject);
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method returns subject that was created and path to it
        /// </summary>
        /// <response code="201">Returns subject that was created and path to it</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message if something had gone wrong</response>

        //POST api/subjects 
        [HttpPost]
        [ProducesResponseType(typeof(SubjectDTO), 201)]
        public async Task<IActionResult> CreateSubject(SubjectDTO subjectDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (subjectDTO.Id != 0)
                    return BadRequest("The Id should be empty");

                var createdSubject = await _subjectService.CreateAsync(subjectDTO);

                //Fetch the subject from data source
                return CreatedAtRoute("GetSubjectById", new {id = createdSubject.Id}, createdSubject);
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method changes subject
        /// </summary>
        /// <response code="204">Returns nothing, subject was successfully changed</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message that subject was not found, if message wasn't returned than id inputted incorrectly</response>

        //PUT api/subjects
        [HttpPut]
        [ProducesResponseType(204)]
        public IActionResult UpdateSubject(SubjectDTO subjectDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _subjectService.Update(subjectDTO);
                return NoContent();
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method deletes subject
        /// </summary>
        /// <response code="204">Returns nothing, subject was successfully deleted</response>
        /// <response code="404">Returns message that subject was not found</response>

        //DELETE api/subjects/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteSubject(int id)
        {
            try
            {
                _subjectService.Remove(id);
                return NoContent();
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}