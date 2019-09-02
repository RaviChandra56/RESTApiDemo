using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApisDemo.Data;
using RESTApisDemo.Models;
using RESTApisDemo.Services;

namespace RESTApisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct _productRepository;
        public ProductsController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/Products
        //https://localhost:44399/api/products?pageNumber=2&pageSize=5
        //https://localhost:44399/api/products?searchProduct=sam with header key ="Accept" & Value ="application/json;v=1.0" and searchProduct="mob"
        [HttpGet]
        public IEnumerable<Product> Get(string sortDesc,int? pageNumber,int? pageSize,string searchProduct)
        {
            return _productRepository.GetProducts(sortDesc, pageNumber, pageSize, searchProduct);
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProduct(id);
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

            _productRepository.AddProduct(product);
           
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
                _productRepository.UpdateProduct(product);
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
            _productRepository.DeleteProduct(id);
            return Ok("Product Deleted...");
        }
    }
}
