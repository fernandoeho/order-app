using System;
using System.Collections.Generic;
using System.Linq;
using Order.Api.Models.Enums;

namespace Order.Api.Models
{
    public class Meal
    {
        public Meal(Guid id, string input, string output)
        {
            Id = id;
            Input = input;
            Output = output;
        }

        public Guid Id { get; private set; }
        public string Input { get; private set; }
        public string Output { get; private set; }
    }
}