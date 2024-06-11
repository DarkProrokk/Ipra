namespace IpraAspNet.Domain.QueryObjects.Interfaces;

public interface IFilterOptions
{
    public string? FilterBy { get; set; }
    
    public string? FilterValue { get; set; }
}