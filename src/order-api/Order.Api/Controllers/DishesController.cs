using Microsoft.AspNetCore.Mvc;
using Order.Api.Infrastructure;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        private readonly OrderContext _context;

        public DishesController(OrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Dishes);
        }
    }
}