using DataLayer.QueryObjects;
using ServiceLayer.IpraService.QueryObject;

namespace ServiceLayer.IpraService;

public class UsersSortFilterPageOptions: SortFilterPageOptions
{
    public string? searchString { get; set; }

    protected override string GenerateCheckState()
    {
        return $"{searchString},{PageSize},{NumPages}";
    }
}