using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Data;
using Movies.Model;

namespace Movies.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _moviesRepository;
        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        // GET: api/Movies
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {        

            return Ok(await _moviesRepository.GetMoviesAsync());
        }


        // GET: api/Movies/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Movie), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var movie = await _moviesRepository.GetAsync(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();

        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]Movie movie)
        {
            return Ok(await _moviesRepository.AddAsync(movie));
        }

        // POST /value
        [HttpPut]
        [ProducesResponseType(typeof(Movie), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put([FromBody]Movie value)
        {
            return Ok(await _moviesRepository.UpdateAsync(value));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int movieId)
        {
            await _moviesRepository.DeleteAsync(movieId);
            return Ok();
        }
    }
}
