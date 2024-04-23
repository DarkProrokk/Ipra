using Microsoft.Extensions.Options;
using ServiceLayer.AuthentificationService;
using ServiceLayer.AuthentificationService.QueryObject;
using ServiceLayer.AuthorizeService.Abstract;
using ServiceLayer.UserService.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AuthorizeService.Concrete
{
    public class LdapAuthentificationService : ILdapAuthentificationService
    {
        public bool CheckAuthenticate(AuthModel person)
        {
            var ds = new ActiveDirectoryUser();
            var sd = ds.GetUserFromAD(person.Login, person.Password);
            return false;
        }
    }
}
