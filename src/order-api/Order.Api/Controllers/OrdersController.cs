using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Controllers.ViewModels;
using Order.Api.Infrastructure;
using Order.Api.Models.Enums;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get works!");
        }

        [HttpPost]
        public IActionResult Post([FromBody]InputViewModel inputViewModel)
        {
            var array = inputViewModel.Input.Split(",");

            ETimeOfDay timeOfDay;
            Enum.TryParse(array[0], true, out timeOfDay);

            foreach (string x in array.Skip(1))
            {
                var dish = _context.Dishes.Where(d => d.TimeOfDay == timeOfDay && d.Type == (EDishType)Convert.ToInt16(x));
            }

            return Ok();
        }
    }
}