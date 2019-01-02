using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Order.Api.Controllers;
using Order.Api.Infrastructure;
using Order.Api.Models;
using Order.Api.Models.Enums;
using Xunit;

namespace Order.UnitTest.Application
{
    public class DishesWebApiTest
    {
        private readonly Mock<OrderContext> _contextMock;

        public DishesWebApiTest()
        {
            _contextMock = new Mock<OrderContext>();
        }

        [Fact]
        public void Get_Dishes_Success()
        {
            // Arrange
            IQueryable<Dish> dishes = new List<Dish>
            {
                new Dish(Guid.NewGuid(), "Eggs", EDishType.Entree, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Toast", EDishType.Side, ETimeOfDay.Morning, false),
                new Dish(Guid.NewGuid(), "Coffee", EDishType.Drink, ETimeOfDay.Morning, true)
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Dish>>();
            dbSetMock.As<IQueryable<Dish>>().Setup(d => d.Provider).Returns(dishes.Provider);
            dbSetMock.As<IQueryable<Dish>>().Setup(d => d.Expression).Returns(dishes.Expression);
            dbSetMock.As<IQueryable<Dish>>().Setup(d => d.ElementType).Returns(dishes.ElementType);
            dbSetMock.As<IQueryable<Dish>>().Setup(d => d.GetEnumerator()).Returns(dishes.GetEnumerator());

            _contextMock.Setup(x => x.Dishes).Returns(dbSetMock.Object);

            // Act
            var dishesController = new DishesController(_contextMock.Object);
            var actionResult = dishesController.GetAll() as OkObjectResult;

            // Assert
            Assert.Equal(actionResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal(3, ((DbSet<Dish>)actionResult.Value).ToList().Count);
        }
    }
}