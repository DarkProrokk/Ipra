using DataLayer.QueryObjects;
using ServiceLayer.IpraService.QueryObject;

namespace ServiceLayer.IpraService;

public class UsersSortFilterPageOptions: SortFilterPageOptions
{
    protected override string GenerateCheckState()
    {
        return $"{PageSize},{NumPages}";
    }
}