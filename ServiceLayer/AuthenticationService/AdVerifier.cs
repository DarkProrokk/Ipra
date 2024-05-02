using Microsoft.Extensions.Options;
using ServiceLayer.UserService.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceLayer.AuthenticationService
{
    public class AdVerifier
    {
        private const string MemberOfAttribute = "memberOf";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        private readonly LdapConfig _ldapConfig;

        public AdVerifier(IOptions<LdapConfig> config)
        {
            _ldapConfig = config.Value;
        }
        
        /// <summary>
        /// Метод проверяет наличие пользователя в AD
        /// </summary>
        /// <param name="person">Параметры пользователя</param>
        /// <returns>true - пользователь найден, false - пользователь не найден</returns>
        public bool AdAccountExists(AuthenticationModel person)
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
    }
}
