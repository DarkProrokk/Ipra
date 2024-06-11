using IpraAspNet.Application.Services.UserService;
using IpraAspNet.Application.UserService;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.QueryObjects.Interfaces;


namespace IpraAspNet.Application.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Возвращает отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.
        /// </summary>

        /// <param name="pagingOptions"></param>
        /// <param name="filterOptions"></param>
        /// <returns>Отсортированный и отфильтрованный список UsersListDto, разбитый на страницы.</returns>
        public IEnumerable<UsersListDto> GetSortedFilteredPage(UsersPagingOptions pagingOptions, UsersFilterOptions filterOptions);


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
