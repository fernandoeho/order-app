using System.Collections.Generic;
using Order.Api.Models;
using Order.Api.Models.Enums;

namespace Order.Api.Infrastructure
{
    public class FakeContext
    {
        public FakeContext()
        {
            Dishes.Add(EDishType.Entree, new[] { Eggs, Steak });
            Dishes.Add(EDishType.Side, new[] { Toast, Potato });
            Dishes.Add(EDishType.Drink, new[] { Coffee, Wine });
            Dishes.Add(EDishType.Dessert, new[] { Error, Cake });
        }

        public Dictionary<EDishType, Dish[]> Dishes = new Dictionary<EDishType, Dish[]>();
        public readonly Dish Eggs = new Dish("Eggs", EDishType.Entree, ETimeOfDay.Morning);
        public readonly Dish Toast = new Dish("Toast", EDishType.Side, ETimeOfDay.Morning);
        public readonly Dish Coffee = new Dish("Coffee", EDishType.Drink, ETimeOfDay.Morning);
        public readonly Dish Error = new Dish("Error", EDishType.Dessert, ETimeOfDay.Morning);
        public readonly Dish Steak = new Dish("Steak", EDishType.Entree, ETimeOfDay.Night);
        public readonly Dish Potato = new Dish("Potato", EDishType.Side, ETimeOfDay.Night);
        public readonly Dish Wine = new Dish("Wine", EDishType.Drink, ETimeOfDay.Night);
        public readonly Dish Cake = new Dish("Cake", EDishType.Dessert, ETimeOfDay.Night);
    }
}