using RESTApisDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApisDemo.Services
{
    public interface IProduct
    {
        //CRUD operations
        IEnumerable<Product> GetProducts(string sortDesc, int? pageNumber, int? pageSize, string searchProduct);
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
