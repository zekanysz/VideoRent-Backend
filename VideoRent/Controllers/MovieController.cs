using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VideoRent.Models;
using VideoRent.Services;

namespace VideoRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _movieService.Get();
        }

        [HttpGet]
        [Route("Available")]
        public IEnumerable<Movie> GetAvailable()
        {
            return _movieService.GetAvailable();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_movieService.Get(id));
        }

        [HttpGet("GetTitleById/{id}")]
        public string GetTitleById(int id)
        {
            return _movieService.GetTitleById(id).ToString();
        }

        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            return Ok(_movieService.Create(movie));
        }

        [HttpPut]
        public IActionResult Put(Movie movie)
        {
            return Ok(_movieService.Update(movie));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_movieService.Delete(id));
        }
    }
}
