using System.Reflection;
using DataLayer.QueryObjects;
using ServiceLayer.IpraService.Models;
using ServiceLayer.IpraService.QueryObject;
using System.Reflection.PortableExecutable;

namespace ServiceLayer.IpraService;

public class IpraListCombinedDto(
    IpraSortFilterPageOptions sortFilterPageData,
    IEnumerable<IpraListViewModel> ipraList)
{
    public IpraSortFilterPageOptions Options { get; private set; } = sortFilterPageData;

    public IEnumerable<IpraListViewModel> Data { get; private set; } = ipraList;

    /// <summary>
    /// Используется для построения таблицы в <seealso cref="https://127.0.0.1:5001/Home/Test"/>
    /// </summary>
    public Dictionary<string, string> HeadersList { get; private set; } = GetHeaders();


    public static Dictionary<string, string> GetHeaders()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>()
        {
            { "Номер", "Number" },
            { "Имя", "FirstName" },
            { "Фамилия", "Surname" },
            { "Отчество", "Patronymic" },
            { "СНИЛС", "Snils" },
            { "Участок", "Sector" },
            { "Дата Рождения", "BirthDate" },
            { "Краткое наименование", "MoShortName" },
            { "Дата начала", "StartDate" },
            { "Дата окончания", "EndDate" }
        };
        return headers;
    }
}