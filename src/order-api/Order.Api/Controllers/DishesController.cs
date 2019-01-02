using Microsoft.AspNetCore.Mvc;
using Order.Api.Infrastructure;
using Order.Api.Infrastructure.Repositories;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        private readonly IDishRepository _dishRepository;

        public DishesController(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dishRepository.GetAll());
        }
    }
}