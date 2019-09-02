using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApisDemo.Models;

namespace RESTApisDemo.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/movies")]
    [ApiController]
    public class MovieV2Controller : ControllerBase
    {

        static List<MovieV2> _movies = new List<MovieV2>()
        {
            new MovieV2{ Id=1, MovieName="Movie 1", MovieDescription="Description 1", Type="Action"},
            new MovieV2{ Id=2, MovieName="Movie 2", MovieDescription="Description 2", Type="Action"},
            new MovieV2{ Id=3, MovieName="Movie 3", MovieDescription="Description 3", Type="Action"}
        };

        //https://localhost:44399/api/movies?api-version=2.0
        // GET: api/MovieV2
        [HttpGet]
        public IEnumerable<MovieV2> Get()
        {
            return _movies;
        }

        // GET: api/MovieV2/5
        [HttpGet("{id}", Name = "GetMovies2")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MovieV2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MovieV2/5
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
