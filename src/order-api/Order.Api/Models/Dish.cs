using System;
using Order.Api.Models.Enums;

namespace Order.Api.Models
{
    public class Dish
    {
        public Dish(Guid id, string name, EDishType type, ETimeOfDay timeOfDay)
        {
            Id = id;
            Name = name;
            Type = type;
            TimeOfDay = timeOfDay;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public EDishType Type { get; private set; }
        public ETimeOfDay TimeOfDay { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}/{2}", Name, Type, TimeOfDay);
        }
    }
}