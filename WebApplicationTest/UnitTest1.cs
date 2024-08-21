using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication6.Controllers;
using WebApplication6.Data;
using WebApplication6.Models;
using Xunit;

namespace WebApplicationTest
{
    public class FormdataControllerTests
    {
        private readonly DbContextOptions<AppdbContext> _dbContextOptions;

        public FormdataControllerTests()
        {
            // Set up in-memory database
            _dbContextOptions = new DbContextOptionsBuilder<AppdbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
        }

        [Fact]
        public async Task AddOrUpdateFormData_Adds_New_Record()
        {
            // Arrange
            using var context = new AppdbContext(_dbContextOptions);
            var controller = new FormdataController(context);

            var formData = new Formdata
            {
                Name = "TestName",
                Description = "Test Description",
                Monitor = "Test Monitor",
                TestUrl = "http://testurl.com",
                RequestType = "GET",
                IsActive = true,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1)
            };

            // Act
            var result = await controller.AddOrUpdateFormData(formData);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Formdata>(okResult.Value);
            Assert.Equal("TestName", returnValue.Name);
            Assert.Single(context.Users);
        }

        [Fact]
        public async Task AddOrUpdateFormData_Updates_Existing_Record()
        {
            // Arrange
            using var context = new AppdbContext(_dbContextOptions);
            context.Users.Add(new Formdata
            {
                Name = "ExistingName",
                Description = "Old Description",
                Monitor = "Old Monitor",
                TestUrl = "http://oldurl.com",
                RequestType = "POST",
                IsActive = false,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1)
            });
            await context.SaveChangesAsync();

            var controller = new FormdataController(context);
            var formData = new Formdata
            {
                Name = "ExistingName",
                Description = "Updated Description",
                Monitor = "Updated Monitor",
                TestUrl = "http://newurl.com",
                RequestType = "PUT",
                IsActive = true,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(2)
            };

            // Act
            var result = await controller.AddOrUpdateFormData(formData);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Formdata>(okResult.Value);
            Assert.Equal("Updated Description", returnValue.Description);
            Assert.Single(context.Users);
        }
    }
}
