using IpraAspNet.Domain.QueryObjects.Interfaces;

namespace IpraAspNet.Domain.QueryObjects;

public class PagingOptions: IPagingOptions
{
    public int PageNum { get; set; } = 1;
    
    public int PageSize { get; set; } = 10;
    
    public int PageCount { get; set; }
    
    public bool HasNext { get; set; }
}