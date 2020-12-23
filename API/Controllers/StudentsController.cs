using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// <c>StudentsController</c> is a class.
    /// Contains all http methods for working with students.
    /// </summary>
    /// <remarks>
    /// This class can get, create, delete, edit students.
    /// </remarks>

    // api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// This method returns all students
        /// </summary>
        /// <response code="200">Returns all students</response>
        //GET api/students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        /// <summary>
        /// This method returns student that has an inputted Id property
        /// </summary>
        /// <response code="200">Returns student that has an inputted Id property</response>
        /// <response code="404">Returns message that nothing was found, if message wasn't returned than id inputted incorrectly</response>

        //GET api/students/{id}
        [HttpGet("{id:int}", Name = "GetStudentById")]
        public async Task<IActionResult> GetStudentsById(int id)
        {
            try
            {
                var student = await _studentService.GetByIdAsync(id);
                return Ok(student);
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method returns student that was created and path to it
        /// </summary>
        /// <response code="201">Returns student that was created and path to it</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message if something had gone wrong</response>

        //POST api/students 
        [HttpPost]
        [ProducesResponseType(typeof(StudentDTO), 201)]
        public async Task<IActionResult> CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (studentDTO.Id != 0)
                    return BadRequest("The Id should be empty");

                var createdStudent = await _studentService.CreateAsync(studentDTO);

                //Fetch the student from data source
                return CreatedAtRoute("GetStudentById", new {id = createdStudent.Id}, createdStudent);
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method changes student
        /// </summary>
        /// <response code="204">Returns nothing, student was successfully changed</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message that student was not found, if message wasn't returned than id inputted incorrectly</response>

        //PUT api/students
        [HttpPut]
        [ProducesResponseType(204)]
        public IActionResult UpdateStudent(StudentDTO studentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _studentService.Update(studentDTO);
                return NoContent();
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method deletes student
        /// </summary>
        /// <response code="204">Returns nothing, student was successfully deleted</response>
        /// <response code="404">Returns message that student was not found</response>

        //DELETE api/students/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentService.Remove(id);
                return NoContent();
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method returns students that have an inputted GroupId property
        /// </summary>
        /// <response code="200">Returns students that have an inputted GroupId property</response>

        //GET api/students/group/{id}
        [HttpGet("group/{id:int}")]
        public async Task<IActionResult> GetStudentsByGroupId(int id)
        {
            var students = await _studentService.GetAllByGroupIdAsync(id);
            return Ok(students);
        }
    }
}