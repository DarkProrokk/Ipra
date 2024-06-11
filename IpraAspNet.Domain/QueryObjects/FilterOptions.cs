using IpraAspNet.Domain.QueryObjects.Interfaces;

namespace IpraAspNet.Domain.QueryObjects;

public class FilterOptions: IFilterOptions
{
    public string? FilterBy { get; set; }
    
    public string? FilterValue { get; set; }
}