using IpraAspNet.Application.Dtos;
using IpraAspNet.Application.Services.IpraService;
using IpraAspNet.Application.Services.IpraService.Models;
using IpraAspNet.Application.Services.IpraService.QueryObject;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.QueryObjects.Interfaces;

namespace IpraAspNet.Application.Interfaces;

public interface IIpraService
{
    IEnumerable<IpraListViewModel> SortFilterPage(IpraFilterOptions filterOptions, IpraPagingOptions pagingOptions);
    
    IpraListDto? GetById(int id);
}