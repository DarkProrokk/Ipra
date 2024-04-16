using DataLayer.Entities;
using ServiceLayer.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserService.QueryObject
{
    public static class UsersListDtoSelect
    {
        public static IQueryable<UsersListDto> MapUsersToDto(this IQueryable<User> users)
        {
            return users.Select(item => new UsersListDto
            {
                Id = item.UserId,
                UserName = item.UserName,
                Surname = item.Surname,
                Name = item.Name,
                Patronymic = item.Patronymic,
                Post = item.Post,
                UserMOUsers = item.UserMOUsers,
                UserRoleUsers = item.UserRoleUsers
            });
        }
    }
}
