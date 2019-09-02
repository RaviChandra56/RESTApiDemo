using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApisDemo.Models;

namespace RESTApisDemo.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        static List<MovieV1> _movies = new List<MovieV1>()
        {
            new MovieV1{ Id=1, MovieName="Movie 1"},
            new MovieV1{ Id=2, MovieName="Movie 2"},
            new MovieV1{ Id=3, MovieName="Movie 3"}
        };

        //https://localhost:44399/api/movies?api-version=1.0
        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MovieV1> Get()
        {
            return _movies;
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovies1")]
        public IActionResult Get(int id)
        {
            return Ok(_movies.SingleOrDefault(x=> x.Id == id));
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
