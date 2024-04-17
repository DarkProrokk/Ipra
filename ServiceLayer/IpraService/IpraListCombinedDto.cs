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
    public IpraSortFilterPageOptions IpraSortFilterPageData { get; private set; } = sortFilterPageData;

    public IEnumerable<IpraListViewModel> IpraList { get; private set; } = ipraList;

    public List<string> HeadersList { get; private set; } = GetHeaders();


    public static List<string> GetHeaders()
    {
        List<string> headers = new List<string>();
        foreach (PropertyInfo property in typeof(IpraListViewModel).GetProperties())
        {
            headers.Add(property.Name);
        }

        return headers;
    }
}