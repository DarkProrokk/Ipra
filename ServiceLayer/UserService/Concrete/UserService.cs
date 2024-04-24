using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IpraService;

using ServiceLayer.UserService.Interface;
using ServiceLayer.UserService.Helpers;
using ServiceLayer.UserService.QueryObject;
using ServiceLayer.UserService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .MapUsersToDto()
                .FilterUsersBySearchString(options.searchString)
                .OrderBy(x => x.Id);

            // Устанавливаем дополнительные параметры для Dto.
            options.SetupRestOfDto(usersQuery);

            // Возвращаем результат запроса, разбитый на страницы.
            return usersQuery.Page(options.PageNum - 1, options.PageSize);
        }

        public UserDto GetUserForUpdatePage(int userId)
        {
            return _context.Users
                .AsNoTracking()
                .MapUserToDtoUpdate()
                .FirstOrDefault(u => u.Id == userId);
        }

        public User GetUser(string username)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());
        }

    }
}
