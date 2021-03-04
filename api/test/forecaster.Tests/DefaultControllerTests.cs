using Xunit;
using Moq;
using Forecaster.Services;
using Forecaster.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Forecaster.Models;

namespace Forecaster.Tests
{
    public class DefaultControllerTests
    {
        [Fact]
        public void TestGetProjects()
        {
            //var serviceMock = new Mock<IProjectService>();
            //serviceMock.Setup(p => p.GetOptimalRatings(It.IsAny<List<Break>>())).Returns(() => new Task<List<Break>>(null));
            //var mockController = new DefaultController(serviceMock.Object);
            //var response = mockController.Optimise(null).Result as BadRequestObjectResult;
            //Assert.NotNull(response);
            //Assert.Equal("failed to process request", response.Value);
        }

    }
}
