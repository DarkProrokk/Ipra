using ServiceLayer.AuthentificationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AuthorizeService.Interface
{
    public interface ILdapAuthentificationService
    {
        /// <summary>
        /// Проверяет пользователя в AD.
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Логин пользователя из AD</returns>
        public string GetAdUserLogin(AuthorizationModel person);
    }
}
