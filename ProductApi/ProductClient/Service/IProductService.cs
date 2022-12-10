using ProductClient.Models;
using System.Net;

namespace ProductClient.Service
{
    public interface IProductService
    {
        Task<List<Product?>?> GetProducts();
        Task<Product?> CreateProduct(Product prod);
        Task<Product?> GetProduct(int id);
        Task<Product?> UpdateProduct(Product prod);
        Task<HttpStatusCode> DeleteProduct(int id);
    }
}
