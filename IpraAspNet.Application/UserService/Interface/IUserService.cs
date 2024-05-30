using IpraAspNet.Domain.Entities;
using IpraAspNet.Application.IpraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpraAspNet.Application.UserService.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Возвращает отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.
        /// </summary>
        /// <param name="options">Параметры сортировки и фильтрации.</param>
        /// <returns>Отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.</returns>
        public IQueryable<UsersListDto> GetSortedFilteredPage(UsersSortFilterPageOptions options);


        /// <summary>
        /// Возвращает информацию о пользователе, подходящуюю для страницы изменения данных пользователя
        /// </summary>
        /// <returns>Пользователь, найденный по userId</returns>
        public UserDto GetUserDto(int userId);

        /// <summary>
        /// Возвращает объект User из БД по логину
        /// </summary>
        public Task<User> GetUserAsync(string username);

        /// <summary>
        /// Проверяет наличие пользователя в базе по логину
        /// </summary>
        public Task<bool> AccountExistsAsync(string username);
    }
}
