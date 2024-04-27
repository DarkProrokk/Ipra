using Microsoft.Extensions.Options;
using ServiceLayer.UserService.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AuthenticationService
{
    public class AuthenticationModel
    {
        [Required(ErrorMessage = "Пользователь не найден")]
        public string Login {  get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
