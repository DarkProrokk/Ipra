// using IpraAspNet.Application.UserService;
// using IpraAspNet.Domain.QueryObjects;
//
// namespace IpraAspNet.Application.Services.UserService
// {
//     public class UsersListCombinedDto(SortFilterPageOptions sortFilterPageData, IEnumerable<UsersListDto> usersList): CombinedDto<SortFilterPageOptions, UsersListDto>(sortFilterPageData, usersList)
//     {
//         public new Dictionary<string, string> HeadersList { get; } = GetHeaders();
//
//         private new static Dictionary<string, string> GetHeaders()
//         {
//             return new Dictionary<string, string>
//             {
//                 { "id", "id" },
//                 { "Логин", "userName" },
//                 { "Фамилия", "surname" },
//                 { "Имя", "name" },
//                 { "Отчество", "patronymic" },
//                 { "Должность", "post" },
//                 { "МО", "userMoName" },
//                 { "Роль", "userRoleName" },
//                 { "Номер телефона", "personPhoneNumber" },
//                 { "Email", "email" },
//                 { "Номер рабочего телефона", "workPhoneNumber" }
//             };
//         }
//     }
// }
