using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTApisDemo.Data;
using RESTApisDemo.Models;

namespace RESTApisDemo.Services
{
    public class ProductRepository : IProduct
    {
        private ProductsDbContext _productsDbContext;

        public ProductRepository(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }
        public void AddProduct(Product product)
        {
            _productsDbContext.Products.Add(product);
            _productsDbContext.SaveChanges(true);
        }

        public void DeleteProduct(int id)
        {
            var product = _productsDbContext.Products.Find(id);
            _productsDbContext.Products.Remove(product);
            _productsDbContext.SaveChanges(true);
        }

        public Product GetProduct(int id)
        {
            return _productsDbContext.Products.SingleOrDefault(x => x.ProductId == id);
        }

        public IEnumerable<Product> GetProducts(string sortDesc, int? pageNumber, int? pageSize, string searchProduct)
        {
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;

            IQueryable<Product> products = _productsDbContext.Products.Where(x => x.ProductName.StartsWith(searchProduct)); //1. search Implementation

            switch (sortDesc) //2. sort Implementation
            {
                case "desc":
                    products = products.OrderByDescending(x => int.Parse(x.ProductPrice));
                    break;
                case "asc":
                    products = products.OrderBy(x => int.Parse(x.ProductPrice));
                    break;
                default:
                    break;
            }

            var productItems = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList(); //3. pagination

            return productItems;
        }

        public void UpdateProduct(Product product)
        {
            _productsDbContext.Products.Update(product);
            _productsDbContext.SaveChanges(true);
        }
    }
}
