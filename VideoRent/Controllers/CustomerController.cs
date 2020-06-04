using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoRent.Models;
using VideoRent.Services;

namespace VideoRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.Get();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_customerService.Get(id));
        }


        [HttpGet("GetCustomerNameById/{id}")]
        public string GetCustomerNameById(int id)
        {
            return _customerService.GetNameById(id);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            _customerService.Create(customer);

            return Ok(customer);
        }

        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            return Ok(_customerService.Update(customer));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_customerService.Delete(id));
        }
    }
}
