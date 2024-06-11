using System.Linq.Expressions;
using IpraAspNet.Application.Services.UserService;
using IpraAspNet.Domain.Entities;

namespace IpraAspNet.Application.UserService.Mappers;

public class UserDtoMapper
{
    public Expression<Func<User, UsersListDto>> MapUserToDto()
    {
        return item => new UsersListDto
            {
                Id = item.UserId,
                UserName = item.UserName,
                Surname = item.Surname,
                Name = item.Name,
                Patronymic = item.Patronymic,
                Post = item.Post,
                UserMoName = item.UserMOUsers.FirstOrDefault()!.MO!.Shortname,
                UserRoleName = item.UserRoleUsers.FirstOrDefault()!.Role.RoleName,
                PersonPhoneNumber = item.MobileNumber,
                WorkPhoneNumber = item.OfficialNumber,
                Email = item.UserEmailAddress
            };
    }
}