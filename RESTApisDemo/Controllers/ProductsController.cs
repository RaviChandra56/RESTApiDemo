using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApisDemo.Data;
using RESTApisDemo.Models;

namespace RESTApisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductsDbContext _productsDbContext;

        public ProductsController(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productsDbContext.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productsDbContext.Products.SingleOrDefault(x => x.ProductId == id);
            if(product == null)
            {
                return NotFound("No Record Found.....");
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productsDbContext.Products.Add(product);
            _productsDbContext.SaveChanges(true);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)

            {
                return BadRequest();
            }

            try
            {
                _productsDbContext.Products.Update(product);
                _productsDbContext.SaveChanges(true);
            }
            catch(Exception)
            {
                return NotFound("No record found against this Id....");
            }

            return Ok("Product Updated...");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productsDbContext.Products.SingleOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound("No Record Found.....");
            }

            _productsDbContext.Products.Remove(product);
            _productsDbContext.SaveChanges(true);
            return Ok("Product Deleted...");
        }
    }
}
