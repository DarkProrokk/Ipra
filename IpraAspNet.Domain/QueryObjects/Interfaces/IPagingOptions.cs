namespace IpraAspNet.Domain.QueryObjects.Interfaces;

public interface IPagingOptions
{
    int PageSize { get; set; }
    
    int PageNum { get; set; }
    
    int PageCount { get; set; }
    
    bool HasNext { get; set; }
}