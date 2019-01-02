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
using Order.Api.Infrastructure.Repositories;
using Order.Api.Models;
using Order.Api.Models.Enums;
using Xunit;

namespace Order.UnitTest.Application
{
    public class OrdersWebApiTest
    {
        private readonly Mock<IDishRepository> _dishRepositoryMock;
        private readonly Mock<IMealRepository> _mealRepositoryMock;

        public OrdersWebApiTest()
        {
            _dishRepositoryMock = new Mock<IDishRepository>();
            _dishRepositoryMock.Setup(dr => dr.GetAll()).Returns(new List<Dish>() {
                new Dish(Guid.NewGuid(), "Eggs", EDishType.Entree, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Toast", EDishType.Side, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Coffee", EDishType.Drink, ETimeOfDay.Morning, true)
            });

            _mealRepositoryMock = new Mock<IMealRepository>();
        }

        [Fact]
        public void Get_Orders_Success()
        {
            // Act
            var ordersController = new OrdersController(_mealRepositoryMock.Object, _dishRepositoryMock.Object);
            var actionResult = ordersController.GetAll() as OkObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public void Post_Order_Success()
        {
            // Arrange
            InputViewModel inputViewModel = new InputViewModel { Input = "morning, 1, 2, 3" };

            // Act
            var ordersController = new OrdersController(_mealRepositoryMock.Object, _dishRepositoryMock.Object);
            var actionResult = ordersController.Post(inputViewModel) as OkObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal("eggs, toast, coffee", ((Meal)actionResult.Value).Output);
        }

        [Fact]
        public void Post_Order_InvalidTimeOfDay_BadRequest()
        {
            // Arrange
            InputViewModel inputViewModel = new InputViewModel { Input = "afternoon, 1, 2, 3" };

            // Act
            var ordersController = new OrdersController(_mealRepositoryMock.Object, _dishRepositoryMock.Object);
            var actionResult = ordersController.Post(inputViewModel) as BadRequestObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Post_Order_InvalidDishes_BadRequest()
        {
            // Arrange
            InputViewModel inputViewModel = new InputViewModel { Input = "morning" };

            // Act
            var ordersController = new OrdersController(_mealRepositoryMock.Object, _dishRepositoryMock.Object);
            var actionResult = ordersController.Post(inputViewModel) as BadRequestObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.BadRequest);
        }
    }
}