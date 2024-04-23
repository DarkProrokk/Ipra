using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserService
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Post { get; set; }
        public virtual ICollection<UserMO> UserMOUsers { get; set; } = new List<UserMO>();
        public virtual ICollection<UserRole> UserRoleUsers { get; set; } = new List<UserRole>();
        public string? UserEmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public string? OfficialNumber { get; set; }
        public bool AllMO { get; set; }
        public bool? IsLocal { get; set; }
        public string? Password { get; set; }
    }
}
