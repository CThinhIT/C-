using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductClient.Models;
using System.Net;
using System.Text;

namespace ProductClient.Service
{
    public class ProductService : IProductService
    {
        public const string BASE_ADDR = "http://localhost:56609/api/apiProduct/";
        HttpClient _client;
        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Product>?> GetProducts()
        {
            string url = BASE_ADDR;
            string json = await _client.GetStringAsync(url);
            var prods = JsonConvert.DeserializeObject<List<Product>>(json);
            return prods;
        }
        public async Task<Product?> GetProduct(int id)
        {
            string url = BASE_ADDR + id;
            string json = await _client.GetStringAsync(url);
            var prods = JsonConvert.DeserializeObject<Product>(json);
            return prods;
        }

        public async Task<Product?> CreateProduct(Product prod)
        {
            string url = BASE_ADDR;
            string prodJson = JsonConvert.SerializeObject(prod);
            StringContent prodContent = new StringContent(prodJson, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(url, prodContent);
            if (result.IsSuccessStatusCode)
            {
                var resultJson = await result.Content.ReadAsStringAsync();
                var resultProd = JsonConvert.DeserializeObject<Product>(resultJson);
                return resultProd;
            }
            return null;
        }

        public async Task<Product?> UpdateProduct(Product prod)
        {
            string url = BASE_ADDR;
            string prodJson = JsonConvert.SerializeObject(prod);
            StringContent prodContent = new StringContent(prodJson, Encoding.UTF8, "application/json");
            var result = await _client.PutAsync(url, prodContent);
            if (result.IsSuccessStatusCode)
            {
                var resultJson = await result.Content.ReadAsStringAsync();
                var resultProd = JsonConvert.DeserializeObject<Product>(resultJson);
                return resultProd;
            }
            return null;
        }

        public async Task<HttpStatusCode> DeleteProduct(int id)
        {
            string url = BASE_ADDR + id;
            HttpResponseMessage response = await _client.DeleteAsync(url);
            
            return response.StatusCode;
        }

    }
}
