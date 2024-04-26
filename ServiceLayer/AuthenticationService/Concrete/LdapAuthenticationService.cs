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
    public class LdapAuthenticationService : ILdapAuthentificationService
    {
        private const string MemberOfAttribute = "memberOf";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        private readonly LdapConfig _ldapConfig;

        public LdapAuthenticationService(IOptions<LdapConfig> config)
        {
            _ldapConfig = config.Value;
        }

        public bool IsAdExist(AuthenticationModel person)
        {
            try
            {
                // Установка соединения с сервером AD
                using (LdapConnection connection = new LdapConnection(new LdapDirectoryIdentifier(_ldapConfig.Url)))
                {
                    //Проверка соответствия данных в AD
                    connection.Bind(new NetworkCredential(person.Login, person.Password));

                    var searchFilter = string.Format(_ldapConfig.SearchFilter, person.Login);

                    SearchRequest searchRequest = new SearchRequest(
                    _ldapConfig.SearchBase,
                    searchFilter,
                    SearchScope.Subtree,
                    new[] { MemberOfAttribute, DisplayNameAttribute, SAMAccountNameAttribute, "company" });

                    // Отправка поискового запроса на сервер LDAP с использованием соединения и получение результатов поиска
                    SearchResponse searchResponse = (SearchResponse)connection.SendRequest(searchRequest);

                    // Проверяем количество найденых персон
                    if (searchResponse.Entries.Count == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                // TODO: Добавить логирование
                return false;
            }
        }

        public ClaimsPrincipal GetClaimsPrincipal(User user)
        {
            // Создание списка утверждений для пользователя
            var userClaims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRoleUsers.FirstOrDefault()?.Role.RoleName.ToString() ?? string.Empty)
            };

            // Создание объекта ClaimsPrincipal на основе списка утверждений и указанного типа аутентификации "ldapService"
            var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "ldapService"));
            return principal;
        }
    }
}
