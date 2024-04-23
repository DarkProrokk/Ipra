using DataLayer.Entities;
using Microsoft.Extensions.Options;
using ServiceLayer.UserService.Interface;
using System.DirectoryServices.Protocols;
using System.Net;

namespace ServiceLayer.AuthentificationService.QueryObject
{
    public class ActiveDirectoryUser
    {
        private const string MemberOfAttribute = "memberOf";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        private readonly LdapConfig _ldapConfig;
        private IUserService _userRepository;

        public ActiveDirectoryUser(IOptions<LdapConfig> config, IUserService userService)
        {
            _ldapConfig = config.Value;
            _userRepository = userService;
        }

        public User GetUserFromAD(string login, string password)
        {
            try
            {
                using (LdapConnection connection = new LdapConnection(new LdapDirectoryIdentifier(_ldapConfig.Url)))
                {
                    connection.Bind(new NetworkCredential(login, password));

                    var searchFilter = string.Format(_ldapConfig.SearchFilter, login);

                    SearchRequest searchRequest = new SearchRequest(
                    _ldapConfig.SearchBase,
                    searchFilter,
                    SearchScope.Subtree,
                    new[] { MemberOfAttribute, DisplayNameAttribute, SAMAccountNameAttribute, "company" });

                    SearchResponse searchResponse = (SearchResponse)connection.SendRequest(searchRequest);

                    var ds = searchResponse.ToString();
                    return null;
                }
            }
            catch (LdapException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
