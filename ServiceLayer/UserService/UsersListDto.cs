using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace ServiceLayer.UserService
{
    public class UsersListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Post { get; set; }
        public virtual ICollection<UserMO> UserMOUsers { get; set; } = new List<UserMO>();
        public virtual ICollection<UserRole> UserRoleUsers { get; set; } = new List<UserRole>();
    }
}
