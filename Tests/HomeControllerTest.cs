using IpraAspNet.Domain.Context;
using IpraAspNet.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IpraAspNet.Application.IpraService;

namespace Tests;

public class HomeControllerTest
{
    [Fact]
    public async Task Index_ReturnsViewResult()
    {
        // Arrange
        var contextOptions = InMemoryContextBuilder.ContextBuilder();
        var context = new IpraContext(contextOptions);
        var options = new IpraSortFilterPageOptions();
        HomeController controller = new HomeController(context);

        // Act
        var result = await controller.Index(options);

        // Assert
        Assert.IsType<ViewResult>(result);
    }
}