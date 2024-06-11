using IpraAspNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using IpraAspNet.Application.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpraAspNet.Application.Services.UserService;

namespace IpraAspNet.Application.UserService.Helpers
{
    public static class DtoMapper
    {
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
