using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComerce.Api.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet("getOrderList")]
        public IActionResult GetOrderList()
        {
            List<Orders> lstProduct = new List<Orders>()
            {
                new Orders { OrderId=1,ProductId=1,Price=150,Quantity=2},
                new Orders { OrderId=2,ProductId=3,Price=200,Quantity=3},
            };

            return Ok(lstProduct);
        }
    }
}
