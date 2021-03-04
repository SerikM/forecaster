using Xunit;
using Moq;
using Forecaster.Services;
using Microsoft.AspNetCore.Mvc;
using Forecaster.Controllers;

namespace Forecaster.Tests
{
    public class DefaultControllerTests
    {
        [Fact]
        public void TestGetProjects()
        {
            var serviceMock = new Mock<IProjectService>();
            serviceMock.Setup(p => p.GetProjectsForDate(It.IsAny<string>())).Returns(() => MockData.GetProjectResponse());
            var mockController = new ProjectController(serviceMock.Object);
            var response = mockController.Get("01.2020") as OkObjectResult;
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
        }

    }
}
