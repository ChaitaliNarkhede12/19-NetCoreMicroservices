using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("getProductList")]
        public IActionResult GetProductList()
        {
            List<Product> lstProduct = new List<Product>()
            {
            new Product { ProductId=1,ProductName="ProductName1",ProductDesc="Test Desc"},
            new Product { ProductId=2,ProductName="ProductName2",ProductDesc="Test Desc"},
            new Product { ProductId=3,ProductName="ProductName3",ProductDesc="Test Desc"},
            };    

            return Ok(lstProduct);
        }
    }
}
