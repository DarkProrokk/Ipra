using DataLayer.Entities;
using Microsoft.Extensions.Options;
using ServiceLayer.AuthenticationService;
using ServiceLayer.AuthorizeService.Interface;
using ServiceLayer.UserService.Interface;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Security.Claims;

namespace ServiceLayer.AuthorizeService.Concrete
{
    public class LdapAuthenticationService :ILdapAuthenticationService
    {
        private readonly IOptions<LdapConfig> _ldapConfig;
        private readonly IUserService _userService;

        public LdapAuthenticationService(IOptions<LdapConfig> config, IUserService userService)
        {
            _ldapConfig = config;
            _userService = userService;
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync(AuthenticationModel person)
        {
            //Проверка пользователя в базе
            if (!await _userService.AccountExistsAsync(person.Login)) throw new LdapException("Такой пользователь не существует");

            var adVerivier = new AdVerifier(_ldapConfig);
            //Проверка пользователя в AD
            if(!adVerivier.AdAccountExists(person)) throw new LdapException("Неверный логин или пароль");

            var user = await _userService.GetUserAsync(person.Login);

            // Создание списка утверждений для пользователя
            var userClaims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRoleUsers.FirstOrDefault()?.Role.RoleName.ToString() ?? string.Empty)
            };

            // Возвращаем объект ClaimsPrincipal, созданный на основе списка утверждений
            // и указанного типа аутентификации "ldapService"
            return new ClaimsPrincipal(new ClaimsIdentity(userClaims, "ldapService"));
        }
    }
}
