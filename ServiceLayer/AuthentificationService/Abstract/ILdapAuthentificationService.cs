using ServiceLayer.AuthentificationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AuthorizeService.Abstract
{
    public interface ILdapAuthentificationService
    {
        /// <summary>
        /// Проверяет пользователя в AD, устанавливает куки.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool CheckAuthenticate(AuthModel person);
    }
}
