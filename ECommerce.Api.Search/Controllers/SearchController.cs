using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        public readonly IHttpClientFactory httpClientFactory;

        public SearchController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet("getSearchList/{id}")]
        public async Task<IActionResult> GetSearchList(int id)
        {
            try
            {
                var productClient = this.httpClientFactory.CreateClient("ProductServices");
                var productResponse = await productClient.GetAsync($"api/products/getProductList");

                var orderClient = this.httpClientFactory.CreateClient("OrderServices");
                var orderResponse = await orderClient.GetAsync($"api/Orders/getOrderList");

                if (productResponse.IsSuccessStatusCode && orderResponse.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    string productContent = await productResponse.Content.ReadAsStringAsync();
                    var productResult = JsonSerializer.Deserialize<List<Product>>(productContent, options);

                    string orderContent = await orderResponse.Content.ReadAsStringAsync();
                    var OrderResult = JsonSerializer.Deserialize<List<Order>>(orderContent, options);

                    var result = new
                    {
                        Product = productResult,
                        Order = OrderResult
                    };

                    return Ok(result);
                }
                return Ok("Error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
