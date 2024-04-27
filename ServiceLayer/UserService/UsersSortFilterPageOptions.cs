using DataLayer.QueryObjects;

namespace ServiceLayer.UserService;

public class UsersSortFilterPageOptions: SortFilterPageOptions
{
    public string? searchString { get; set; }

    protected override string GenerateCheckState()
    {
        return $"{searchString},{PageSize},{NumPages}";
    }
}