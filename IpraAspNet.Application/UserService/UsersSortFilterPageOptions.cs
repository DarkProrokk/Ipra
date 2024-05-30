using IpraAspNet.Domain.QueryObjects;

namespace IpraAspNet.Application.UserService;

public class UsersSortFilterPageOptions: SortFilterPageOptions
{
    public string? searchString { get; set; }

    protected override string GenerateCheckState()
    {
        return $"{searchString},{PageSize},{NumPages}";
    }
}