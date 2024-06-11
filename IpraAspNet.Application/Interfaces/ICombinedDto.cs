using IpraAspNet.Domain.QueryObjects.Interfaces;

namespace IpraAspNet.Application.Interfaces;

public interface ICombinedDto<out TFilterOptions, out TPagingOptions, out TModel> where TFilterOptions : IFilterOptions where TModel : class where TPagingOptions: IPagingOptions
{
    TFilterOptions FilterOptions { get; }
    
    TPagingOptions PagingOptions { get; }
    IEnumerable<TModel> Data { get; }
    
    Dictionary<string, string> HeadersList { get; }

    static abstract Dictionary<string, string> GetHeaders();
}