using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// <c>RatingsController</c> is a class.
    /// Contains all http methods for working with ratings.
    /// </summary>
    /// <remarks>
    /// This class can get, create, delete, edit ratings.
    /// </remarks>

    // api/ratings
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// This method returns all ratings
        /// </summary>
        /// <response code="200">Returns all ratings</response>

        //GET api/ratings
        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllAsync();
            return Ok(ratings);
        }

        /// <summary>
        /// This method returns rating that has an inputted Id property
        /// </summary>
        /// <response code="200">Returns rating that has an inputted Id property</response>
        /// <response code="404">Returns message that nothing was found, if message wasn't returned than id inputted incorrectly</response>

        //GET api/ratings/{id}
        [HttpGet("{id:int}", Name = "GetRatingById")]
        public async Task<IActionResult> GetRatingById(int id)
        {
            try
            {
                var rating = await _ratingService.GetByIdAsync(id);
                return Ok(rating);
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method returns rating that was created and path to it
        /// </summary>
        /// <response code="201">Returns rating that was created and path to it</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message if something had gone wrong</response>

        //POST api/ratings 
        [HttpPost]
        [ProducesResponseType(typeof(RatingDTO), 201)]
        public async Task<IActionResult> CreateRating(RatingDTO ratingDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (ratingDTO.Id != 0)
                    return BadRequest("The Id should be empty");

                var createdRating = await _ratingService.CreateAsync(ratingDTO);

                //Fetch the rating from data source
                return CreatedAtRoute("GetRatingById", new {id = createdRating.Id}, createdRating);
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method changes rating
        /// </summary>
        /// <response code="204">Returns nothing, rating was successfully changed</response>
        /// <response code="400">Returns message why model is invalid</response>
        /// <response code="404">Returns message that rating was not found, if message wasn't returned than id inputted incorrectly</response>

        //PUT api/ratings
        [HttpPut]
        [ProducesResponseType(204)]
        public IActionResult UpdateRating(RatingDTO ratingDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _ratingService.Update(ratingDTO);
                return NoContent();
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method deletes rating
        /// </summary>
        /// <response code="204">Returns nothing, rating was successfully deleted</response>
        /// <response code="404">Returns message that rating was not found</response>

        //DELETE api/ratings/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteRating(int id)
        {
            try
            {
                _ratingService.Remove(id);
                return NoContent();
            }
            catch (DbResultException e)
            {
                return NotFound(e.Message);
            }
        }
        
        /// <summary>
        /// This method returns ratings that have an inputted SubjectId property
        /// </summary>
        /// <response code="200">Returns ratings that have an inputted SubjectId property</response>
        
        //GET api/ratings/subject/{id}
        [HttpGet("subject/{id:int}")]
        public async Task<IActionResult> GetRatingBySubjectId(int id)
        {
            var ratings = await _ratingService.GetAllBySubjectIdAsync(id);
            return Ok(ratings);
        }
        
        
        /// <summary>
        /// This method returns ratings that have an inputted StudentId property
        /// </summary>
        /// <response code="200">Returns ratings that have an inputted StudentId property</response>
        
        //GET api/ratings/student/{id}
        [HttpGet("brand/{id:int}")]
        public async Task<IActionResult> GetRatingByStudentId(int id)
        {
            var ratings = await _ratingService.GetAllByStudentIdAsync(id);
            return Ok(ratings);
        }
        
    }
}