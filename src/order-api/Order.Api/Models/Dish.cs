using System;
using Order.Api.Models.Enums;

namespace Order.Api.Models
{
    public class Dish
    {
        public Dish(string name, EDishType type, ETimeOfDay timeOfDay)
        {
            Name = name;
            Type = type;
            TimeOfDay = timeOfDay;
        }

        public string Name { get; private set; }
        public EDishType Type { get; private set; }
        public ETimeOfDay TimeOfDay { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}/{2}", Name, Type, TimeOfDay);
        }
    }
}