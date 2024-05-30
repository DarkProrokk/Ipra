using IpraAspNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using IpraAspNet.Application.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpraAspNet.Application.UserService.Helpers
{
    public static class DtoMapper
    {
        /// <summary>
        /// Преобразует сущности User в Dto.
        /// UsersListDto - модель для отображения на странице администрирования пользователей.
        /// </summary>
        public static IQueryable<UsersListDto> MapUsersToDtoList(this IQueryable<User> users)
        {
            return users
                .Include(u => u.UserMOUsers)
                .Include(u => u.UserRoleUsers)
                .Select(item => new UsersListDto
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

        /// <summary>
        /// Преобразует сущности User в Dto.
        /// UserDto - модель для отображения на странице изменения пользователя.
        /// </summary>
        public static IQueryable<UserDto> MapUserToDtoUpdate(this IQueryable<User> users) 
        {
            return users
                .Select(item => new UserDto
                {
                    Id = item.UserId,
                    UserName = item.UserName,
                    Surname = item.Surname,
                    Name = item.Name,
                    Patronymic = item.Patronymic,
                    Post = item.Post,
                    UserMOUsers = item.UserMOUsers,
                    UserRoleUsers = item.UserRoleUsers,
                    UserEmailAddress = item.UserEmailAddress,
                    MobileNumber = item.MobileNumber,
                    OfficialNumber = item.OfficialNumber,
                    AllMO = item.AllMO,
                    IsLocal = item.IsLocal,
                    Password = item.Password
                });
        }
    }
}
