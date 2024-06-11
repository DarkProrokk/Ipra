using IpraAspNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using IpraAspNet.Application.UserService.Helpers;
using IpraAspNet.Application.Interfaces;
using IpraAspNet.Application.Services.UserService;
using IpraAspNet.Domain.Interfaces;
using IpraAspNet.Application.UserService.Mappers;
using IpraAspNet.Domain.Specification.Extension;
using IpraAspNet.Infrastructure.Specification;
namespace IpraAspNet.Application.UserService.Concrete
{
    /// <summary>
    /// Класс IpraService предоставляет функционал для сортировки, фильтрации и постраничного вывода данных IpraListDto.
    /// </summary>
    public class UserService(IUserRepository repository = null!) : IUserService
    {
        /// <summary>
        /// Возвращает отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.
        /// </summary>
        /// <param name="pagingOptions"></param>
        /// <param name="filterOptions"></param>
        /// <returns>Отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.</returns>
        public IEnumerable<UsersListDto> GetSortedFilteredPage(UsersPagingOptions pagingOptions, UsersFilterOptions filterOptions)
        {
            var userSpec = new EqualFieldExtension<User>(filterOptions.FilterBy, filterOptions.FilterValue);
            
            var mapperDto = new UserDtoMapper().MapUserToDto();
            
            var usersQuery = repository.GetAll(userSpec, mapperDto, pagingOptions);
            
            return usersQuery;
        }

        public UserDto GetUserDto(int userId)
        {
            return repository.GetAll()
                .AsNoTracking()
                .MapUserToDtoUpdate()
                .FirstOrDefault(u => u.Id == userId);
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await repository.GetAll()
                .AsNoTracking()
                .Include(x => x.UserRoleUsers)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
        }

        public async Task<bool> AccountExistsAsync(string username)
        {
            return await repository.GetAll().FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower()) != null;
        }

    }
}
