using System;
using System.Collections.Generic;
using System.Linq;
using Order.Api.Models.Enums;

namespace Order.Api.Models
{
    public class Meal
    {
        protected Meal(Guid id, string input, string output)
        {
            Id = id;
            Input = input;
            Output = output;
        }

        public Guid Id { get; private set; }
        public string Input { get; private set; }
        public string Output { get; private set; }

        public static Meal Create(string input, List<Dish> dishes)
        {
            var inputArray = input.Replace(" ", string.Empty).Split(",");

            ETimeOfDay timeOfDay;
            if (!Enum.TryParse(inputArray[0], true, out timeOfDay))
                throw new Exception($"'{inputArray[0]}' is not a valid time of day");

            var groups = inputArray.Skip(1).OrderBy(x => x).GroupBy(x => x);

            if (groups.Count() == 0)
                throw new Exception($"Please inform a dish");

            var validDishes = dishes.Where(d => d.TimeOfDay == timeOfDay);

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

            string output = string.Join(",", listOutput);

            return new Meal(Guid.NewGuid(), input, output);
        }
    }
}