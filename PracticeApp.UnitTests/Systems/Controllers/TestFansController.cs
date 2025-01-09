using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PracticeApp.WebApi.Controllers;
using PracticeApp.WebApi.Services.Interfaces;
using PracticeApp.WebApi.Models;

namespace PracticeApp.UnitTests.Systems.Controllers
{
    public class TestFansController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(new List<Fan>());

            var fansController = new FansController(mockFanService.Object);

            // Act
            var result = (OkObjectResult) await fansController.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
