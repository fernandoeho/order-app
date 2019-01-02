using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Order.Api.Controllers;
using Order.Api.Infrastructure;
using Order.Api.Infrastructure.Repositories;
using Order.Api.Models;
using Order.Api.Models.Enums;
using Xunit;

namespace Order.UnitTest.Application
{
    public class DishesWebApiTest
    {
        private readonly Mock<IDishRepository> _dishRepositoryMock;

        public DishesWebApiTest()
        {
            _dishRepositoryMock = new Mock<IDishRepository>();
        }

        [Fact]
        public void Get_Dishes_Success()
        {
            // Arrange
            _dishRepositoryMock.Setup(dr => dr.GetAll()).Returns(new List<Dish>() {
                new Dish(Guid.NewGuid(), "Eggs", EDishType.Entree, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Toast", EDishType.Side, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Coffee", EDishType.Drink, ETimeOfDay.Morning, true)
            });

            // Act
            var dishesController = new DishesController(_dishRepositoryMock.Object);
            var actionResult = dishesController.GetAll() as OkObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal(3, ((List<Dish>)actionResult.Value).ToList().Count);
        }
    }
}