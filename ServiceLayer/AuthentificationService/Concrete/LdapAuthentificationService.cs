using DataLayer.Entities;
using Microsoft.Extensions.Options;
using ServiceLayer.AuthentificationService;
using ServiceLayer.AuthorizeService.Interface;
using ServiceLayer.UserService.Interface;
using System.DirectoryServices.Protocols;
using System.Net;

namespace ServiceLayer.AuthorizeService.Concrete
{
    public class LdapAuthentificationService : ILdapAuthentificationService
    {
        private const string MemberOfAttribute = "memberOf";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        private readonly LdapConfig _ldapConfig;

        public LdapAuthentificationService(IOptions<LdapConfig> config)
        {
            _ldapConfig = config.Value;
        }

        public string GetAdUserLogin(AuthorizationModel person)
        {
            //Todo docstring + комментарии
            using (LdapConnection connection = new LdapConnection(new LdapDirectoryIdentifier(_ldapConfig.Url)))
            {
                connection.Bind(new NetworkCredential(person.Login, person.Password));

                var searchFilter = string.Format(_ldapConfig.SearchFilter, person.Login);

                SearchRequest searchRequest = new SearchRequest(
                _ldapConfig.SearchBase,
                searchFilter,
                SearchScope.Subtree,
                new[] { MemberOfAttribute, DisplayNameAttribute, SAMAccountNameAttribute, "company" });

                SearchResponse searchResponse = (SearchResponse)connection.SendRequest(searchRequest);

                if (searchResponse.Entries.Count == 1)
                {
                    return searchResponse.Entries[0].Attributes["sAMAccountName"][0].ToString();
                }
                //Todo возвращать ошибку, вместо null
                return null;
            }
        }
    }
}
