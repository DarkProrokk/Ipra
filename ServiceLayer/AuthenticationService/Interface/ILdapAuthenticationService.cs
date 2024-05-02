using DataLayer.Entities;
using ServiceLayer.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AuthorizeService.Interface
{
    public interface ILdapAuthenticationService
    {
        /// <summary>
        /// Метод для создания объекта ClaimsPrincipal на основе данных пользователя.
        /// Если роль пользователя доступна, добавляет утверждение о роли, иначе добавляет пустую строку.
        /// Создает объект ClaimsPrincipal с указанным именем и списком утверждений и возвращает его.
        /// </summary>
        /// <param name="user">Объект пользователя</param>
        /// <returns></returns>
        public Task<ClaimsPrincipal> GetClaimsPrincipalAsync(AuthenticationModel user);
    }
}
