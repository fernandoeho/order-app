using Microsoft.AspNetCore.Mvc;
using Order.Api.Controllers.ViewModels;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get works!");
        }

        [HttpPost]
        public IActionResult Post([FromBody]InputViewModel input)
        {
            return Ok(input);
        }
    }
}