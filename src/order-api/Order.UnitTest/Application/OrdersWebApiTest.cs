using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Order.Api.Controllers;
using Order.Api.Controllers.ViewModels;
using Order.Api.Infrastructure;
using Order.Api.Models;
using Order.Api.Models.Enums;
using Xunit;

namespace Order.UnitTest.Application
{
    public class OrdersWebApiTest
    {
        private readonly Mock<OrderContext> _contextMock;

        public OrdersWebApiTest()
        {
            _contextMock = new Mock<OrderContext>();

            IQueryable<Dish> dishes = new List<Dish>
            {
                new Dish(Guid.NewGuid(), "Eggs", EDishType.Entree, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Toast", EDishType.Side, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Coffee", EDishType.Drink, ETimeOfDay.Morning, true)
            }.AsQueryable();

            IQueryable<Meal> meals = new List<Meal>().AsQueryable();

            var dishesDbSetMock = new Mock<DbSet<Dish>>();
            dishesDbSetMock.As<IQueryable<Dish>>().Setup(d => d.Provider).Returns(dishes.Provider);
            dishesDbSetMock.As<IQueryable<Dish>>().Setup(d => d.Expression).Returns(dishes.Expression);
            dishesDbSetMock.As<IQueryable<Dish>>().Setup(d => d.ElementType).Returns(dishes.ElementType);
            dishesDbSetMock.As<IQueryable<Dish>>().Setup(d => d.GetEnumerator()).Returns(dishes.GetEnumerator());

            var mealsDbSetMock = new Mock<DbSet<Meal>>();
            mealsDbSetMock.As<IQueryable<Meal>>().Setup(d => d.Provider).Returns(meals.Provider);
            mealsDbSetMock.As<IQueryable<Meal>>().Setup(d => d.Expression).Returns(meals.Expression);
            mealsDbSetMock.As<IQueryable<Meal>>().Setup(d => d.ElementType).Returns(meals.ElementType);
            mealsDbSetMock.As<IQueryable<Meal>>().Setup(d => d.GetEnumerator()).Returns(meals.GetEnumerator());

            _contextMock.Setup(x => x.Meals).Returns(mealsDbSetMock.Object);
            _contextMock.Setup(x => x.Dishes).Returns(dishesDbSetMock.Object);
        }

        [Fact]
        public void Get_Orders_Success()
        {
            // Act
            var ordersController = new OrdersController(_contextMock.Object);
            var actionResult = ordersController.Get() as OkObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public void Post_Order_Success()
        {
            // Arrange
            InputViewModel inputViewModel = new InputViewModel { Input = "morning, 1, 2, 3" };

            // Act
            var ordersController = new OrdersController(_contextMock.Object);
            var actionResult = ordersController.Post(inputViewModel) as OkObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal("eggs,toast,coffee", ((Meal)actionResult.Value).Output);
        }

        [Fact]
        public void Post_Order_InvalidTimeOfDay_BadRequest()
        {
            // Arrange
            InputViewModel inputViewModel = new InputViewModel { Input = "afternoon, 1, 2, 3" };

            // Act
            var ordersController = new OrdersController(_contextMock.Object);
            var actionResult = ordersController.Post(inputViewModel) as BadRequestObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.BadRequest);
        }
    }
}