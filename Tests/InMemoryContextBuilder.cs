using IpraAspNet.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public static class InMemoryContextBuilder
{
    public static DbContextOptions<IpraContext> ContextBuilder()
    {
        var options = new DbContextOptionsBuilder<IpraContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        return options;
    }
}