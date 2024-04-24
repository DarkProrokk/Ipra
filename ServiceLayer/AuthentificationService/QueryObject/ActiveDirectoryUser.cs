using DataLayer.Entities;
using Microsoft.Extensions.Options;
using ServiceLayer.UserService.Interface;
using System.DirectoryServices.Protocols;
using System.Net;

namespace ServiceLayer.AuthentificationService.QueryObject
{
    public static class ActiveDirectoryUser
    {
        private const string MemberOfAttribute = "memberOf";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        public static User GetUserFromAD(this AuthModel person, LdapConfig ldapConfig, IUserService userRepository)
        {
            try
            {
                using (LdapConnection connection = new LdapConnection(new LdapDirectoryIdentifier(ldapConfig.Url)))
                {
                    connection.Bind(new NetworkCredential(person.Login, person.Password));

                    var searchFilter = string.Format(ldapConfig.SearchFilter, person.Login);

                    SearchRequest searchRequest = new SearchRequest(
                    ldapConfig.SearchBase,
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
