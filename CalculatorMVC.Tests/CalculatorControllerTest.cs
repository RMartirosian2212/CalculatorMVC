using Microsoft.AspNetCore.Mvc.Testing;
using CalculatorMVC;
using System.Net;
using Azure.Core;
using CalculatorMVC_DataAccess.Repositories;
using Moq;
using CalculatorMVC.Controllers;
using CalculatorMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorMVC_Tests
{
    public class CalculatorControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IRepository<Calculator, int>> _mockRepo;
        private readonly HomeController _controller;
        public CalculatorControllerTest(WebApplicationFactory<Program> factory)
        {
            _mockRepo = new Mock<IRepository<Calculator, int>>();
            _controller = new HomeController(_mockRepo.Object);
            _factory = factory;
        }
        [Theory]
        [InlineData("/")]
        public async void Calculator_Index(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            int code = (int)response.StatusCode;
            Assert.Equal(200, code);
        }
        [Fact]
        public void CalculatorIndex()
        {
            var result = _controller.Index(null);
            Assert.IsType<ViewResult>(result);
        }
    }
}