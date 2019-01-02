using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Controllers.ViewModels;
using Order.Api.Infrastructure;
using Order.Api.Infrastructure.Repositories;
using Order.Api.Models;
using Order.Api.Models.Enums;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IMealRepository _mealRepository;
        private readonly IDishRepository _dishRepository;

        public OrdersController(IMealRepository mealRepository, IDishRepository dishRepository)
        {
            _mealRepository = mealRepository;
            _dishRepository = dishRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mealRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody]InputViewModel inputViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var meal = GetMeal(inputViewModel.Input);

                _mealRepository.Add(meal);
                _mealRepository.SaveChanges();

                return Ok(meal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private Meal GetMeal(string input)
        {
            var inputArray = input.Replace(" ", string.Empty).Split(",");

            ETimeOfDay timeOfDay;
            if (!Enum.TryParse(inputArray[0], true, out timeOfDay))
                throw new Exception($"'{inputArray[0]}' is not a valid time of day");

            var groups = inputArray.Skip(1).OrderBy(x => x).GroupBy(x => x);

            if (groups.Count() == 0)
                throw new Exception($"Please inform a dish");

            var validDishes = _dishRepository.GetAll().Where(d => d.TimeOfDay == timeOfDay);

            List<string> listOutput = new List<string>();

            foreach (var item in groups)
            {
                var dish = validDishes.Where(d => d.Type == (EDishType)Convert.ToInt16(item.Key)).FirstOrDefault();

                if (dish != null)
                {
                    if (dish.MultipleOrders && item.Count() > 1)
                    {
                        listOutput.Add(dish.Name.ToLowerInvariant() + $"(x{item.Count()})");
                    }
                    else if (!dish.MultipleOrders && item.Count() > 1)
                    {
                        listOutput.Add(dish.Name.ToLowerInvariant());
                        listOutput.Add("error");
                        break;
                    }
                    else
                    {
                        listOutput.Add(dish.Name.ToLowerInvariant());
                    }
                }
                else
                {
                    listOutput.Add("error");
                    break;
                }
            }

            string output = string.Join(", ", listOutput);

            return new Meal(Guid.NewGuid(), input, output);
        }
    }
}