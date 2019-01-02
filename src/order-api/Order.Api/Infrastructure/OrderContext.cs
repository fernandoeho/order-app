using System;
using Microsoft.EntityFrameworkCore;
using Order.Api.Models;
using Order.Api.Models.Enums;

namespace Order.Api.Infrastructure
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options) { }

        public OrderContext() { }

        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().HasData(
                new Dish(Guid.NewGuid(), "Eggs", EDishType.Entree, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Toast", EDishType.Side, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Coffee", EDishType.Drink, ETimeOfDay.Morning, true),
                new Dish(Guid.NewGuid(), "Steak", EDishType.Entree, ETimeOfDay.Night, false),
                new Dish(Guid.NewGuid(), "Potato", EDishType.Side, ETimeOfDay.Night, true),
                new Dish(Guid.NewGuid(), "Wine", EDishType.Drink, ETimeOfDay.Night, false),
                new Dish(Guid.NewGuid(), "Cake", EDishType.Dessert, ETimeOfDay.Night, false)
            );
        }

    }
}