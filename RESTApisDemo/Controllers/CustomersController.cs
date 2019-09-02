using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTApisDemo.Models;

namespace RESTApisDemo.Controllers
{
    public class CustomersController : Controller
    {
        static List<Customer> _customers = new List<Customer>()
        {
            new Customer { Id =1, Name ="Product 1", Email="ravi.chandra@gmail.com" ,Phone ="110"},
            new Customer { Id =2, Name ="Product 2", Email="ravi.chandra@gmail.com" ,Phone ="120"},
            new Customer { Id =3, Name ="Product 3", Email="ravi.chandra@gmail.com" ,Phone ="130"},
        };

        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if(ModelState.IsValid)
            {
                _customers.Add(customer);
                return Ok();
            }

            return BadRequest();
        }
    }
}