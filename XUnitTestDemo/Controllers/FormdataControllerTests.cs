using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Controllers;
using WebApplication6.Data;
using WebApplication6.Models;
using Xunit;

public class FormdataControllerTests
{
    private readonly DbContextOptions<AppdbContext> _dbContextOptions;

    public FormdataControllerTests()
    {
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
}
