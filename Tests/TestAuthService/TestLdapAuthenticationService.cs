/*using System.DirectoryServices.Protocols;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using IpraAspNet.Application.AuthorizeService.Interface;
using Moq;
using IpraAspNet.Application.AuthenticationService;
using IpraAspNet.Application.AuthorizeService.Concrete;


namespace Tests.TestAuthService;

public class TestLdapAuthenticationService
{
    private readonly LdapAuthenticationService _service;

    public TestLdapAuthenticationService()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        LdapConfig? ldapConfig = configuration.GetSection("Ldap").Get<LdapConfig>();
        IOptions<LdapConfig> options = Options.Create(ldapConfig);
        _service = new LdapAuthenticationService(options);
    }
    [Theory]
    [InlineData(null, null)]
    public void TestGetUserInAd(string login, string password)
    {
        //Arrange
        AuthenticationModel model = new AuthenticationModel()
        {
            Login = login,
            Password = password
        };
        //Art
        bool user = _service.IsAdExist(model);
        //Assert
        Assert.False(user);
    }
}*/