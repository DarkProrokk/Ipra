using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.UserService.Helpers;
using ServiceLayer.UserService.Interface;
using ServiceLayer.UserService.QueryObject;

namespace ServiceLayer.UserService.Concrete
{
    /// <summary>
    /// Класс ListIpraService предоставляет функционал для сортировки, фильтрации и постраничного вывода данных IpraListDto.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IpraContext _context;

        /// <summary>
        /// Конструктор класса ListIpraService.
        /// </summary>
        /// <param name="context">Экземпляр контекста IpraContext.</param>
        public UserService(IpraContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.
        /// </summary>
        /// <param name="options">Параметры сортировки и фильтрации.</param>
        /// <returns>Отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.</returns>
        public IQueryable<UsersListDto> GetSortedFilteredPage(UsersSortFilterPageOptions options)
        {
            // Создаем запрос, который будет использоваться для сортировки и фильтрации данных.
            IQueryable<UsersListDto> usersQuery = _context.Users
                .AsNoTracking() // Отключаем отслеживание изменений объектов.
                .MapUsersToDtoList()
                .FilterUsersBySearchString(options.searchString)
                .OrderBy(x => x.Id);

            // Устанавливаем дополнительные параметры для Dto.
            options.SetupRestOfDto(usersQuery);

            // Возвращаем результат запроса, разбитый на страницы.
            return usersQuery.Page(options.PageNum - 1, options.PageSize);
        }

        public UserDto GetUserDto(int userId)
        {
            return _context.Users
                .AsNoTracking()
                .MapUserToDtoUpdate()
                .FirstOrDefault(u => u.Id == userId);
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(x => x.UserRoleUsers)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
        }

        public async Task<bool> AccountExistsAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower()) != null;
        }

    }
}
