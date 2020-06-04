using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoRent.Models;
using VideoRent.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {

        private readonly RentService _rentService;

        public RentController(RentService rentService)
        {
            _rentService = rentService;
        }
        [HttpGet]
        public IEnumerable<Rent> Get()
        {
            return _rentService.Get();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_rentService.Get(id));
        }

        [HttpPost]
        public IActionResult Post(Rent rent)
        {
            return Ok(_rentService.Create(rent));
        }

        [HttpPut]
        public IActionResult Put(Rent rent)
        {
            return Ok(_rentService.Update(rent));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_rentService.Delete(id));
        }
    }
}
