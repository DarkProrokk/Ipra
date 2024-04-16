using DataLayer.QueryObjects;
using ServiceLayer.IpraService.QueryObject;

namespace ServiceLayer.IpraService;

public class IpraListCombinedDto(
    IpraSortFilterPageOptions sortFilterPageData,
    IEnumerable<IpraListDto> ipraList)
{
    public IpraSortFilterPageOptions IpraSortFilterPageData { get; private set; } = sortFilterPageData;

    public IEnumerable<IpraListDto> IpraList { get; private set; } = ipraList;
}