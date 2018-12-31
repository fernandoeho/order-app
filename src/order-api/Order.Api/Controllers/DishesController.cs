using Microsoft.AspNetCore.Mvc;
using Order.Api.Infrastructure;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        private readonly FakeContext _context;

        public DishesController(FakeContext context)
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