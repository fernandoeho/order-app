using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Controllers.ViewModels;
using Order.Api.Infrastructure;
using Order.Api.Models;
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
            return Ok(_context.Meals);
        }

        [HttpPost]
        public IActionResult Post([FromBody]InputViewModel inputViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var meal = Meal.Create(inputViewModel.Input, _context.Dishes.ToList());

                _context.Meals.Add(meal);
                _context.SaveChanges();

                return Ok(meal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}