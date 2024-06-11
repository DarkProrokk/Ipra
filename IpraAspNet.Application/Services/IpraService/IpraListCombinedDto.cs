// using System.Reflection;
// using IpraAspNet.Domain.QueryObjects;
// using System.Reflection.PortableExecutable;
// using IpraAspNet.Application.Interfaces;
// using IpraAspNet.Application.Services.IpraService.Models;
// using IpraAspNet.Application.Services.IpraService.QueryObject;
// using IpraAspNet.Domain.QueryObjects.Interfaces;
//
// namespace IpraAspNet.Application.Services.IpraService;
//
// public class IpraListCombinedDto(
//     IEnumerable<IpraListViewModel> ipraList)
//     : CombinedDto<IpraListViewModel>(ipraList)
// {
//     public new Dictionary<string, string> HeadersList { get; } = GetHeaders();
//
//     private new static Dictionary<string, string> GetHeaders()
//     {
//         Dictionary<string, string> headers = new Dictionary<string, string>()
//         {
//             {"Id", "Id"},
//             { "Номер", "Number" },
//             { "Имя", "FirstName" },
//             { "Фамилия", "Surname" },
//             { "Отчество", "Patronymic" },
//             { "СНИЛС", "Snils" },
//             { "Участок", "Sector" },
//             { "Дата Рождения", "BirthDate" },
//             { "Краткое наименование", "MoShortName" },
//             { "Дата начала", "StartDate" },
//             { "Дата окончания", "EndDate" }
//         };
//         return headers;
//     }
// }