using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApisDemo.Models;

namespace RESTApisDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        static List<Product> _products = new List<Product>()
        {
            new Product { ProductId =1, ProductName ="Product 1", ProductPrice ="110"},
            new Product { ProductId =2, ProductName ="Product 2", ProductPrice ="120"},
            new Product { ProductId =3, ProductName ="Product 3", ProductPrice ="130"},
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_products);
            //return BadRequest(); 400
            //return NotFound(); 404
        }

        [HttpGet("LoadWelcomeMessage")]
        public IActionResult GetWelcomeMessage()
        {
            return Ok("Welcome to Web api");
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {
            _products[id] = product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }
    }
}