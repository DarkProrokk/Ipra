using IpraAspNet.Application.Dtos;
using IpraAspNet.Application.Interfaces;
using IpraAspNet.Application.Services.IpraService.Models;
using IpraAspNet.Application.Services.IpraService.QueryObject;
using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Interfaces;
using IpraAspNet.Domain.QueryObjects;
using IpraAspNet.Domain.Specification;
using IpraAspNet.Domain.Specification.Extension;
using IpraAspNet.Infrastructure.Specification;

using static IpraAspNet.Application.IpraService.Mappers.IpraMappers;

namespace IpraAspNet.Application.Services.IpraService.Concrete;

/// <summary>
/// Класс IpraService предоставляет функционал для сортировки, фильтрации и постраничного вывода данных IpraListDto.
/// </summary>
public class IpraService(IIpraRepository ipraRepository): IIpraService
{
    /// <summary>
    /// Метод SortFilterPage возвращает отсортированный и отфильтрованный список IpraListDto, разбитый на страницы.
    /// </summary>
    /// <param name="filterOptions">Параметры фильтрации.</param>
    /// <param name="pagingOptions">Параметры пагинации</param>
    /// <returns>Отсортированный и отфильтрованный список IpraListDto, разбитый на страницы.</returns>
    public IEnumerable<IpraListViewModel> SortFilterPage(IpraFilterOptions filterOptions, IpraPagingOptions pagingOptions)
    {
        var statusSpec = new IpraStatusSpecification(filterOptions.FilterByStatus);
        var endlessSpec = new IpraEndlessSpecification(filterOptions.FilterByEndless);
        var searchSpec = new EqualFieldExtension<Ipra>(filterOptions.FilterBy, filterOptions.FilterValue);
        
        var combSpec = new AndSpecification<Ipra, bool>(statusSpec, endlessSpec);
        var finnalySpec = new AndSpecification<Ipra, bool>(combSpec, searchSpec);
        
        var mapperDto = IpraToListDtoMapper();
        
        var ipraAfterRepo = ipraRepository.GetAll(finnalySpec, mapperDto, pagingOptions);
        
        var ipraQuery = ipraAfterRepo.MapDtoToViewModel();
        
        return ipraQuery;
    }
    
    public IpraListDto GetById(int id)
    {
        var mapperDto = IpraToListDtoMapper();

        var idSpec = new IpraByIdSpecification(id);
        
        var ipra = ipraRepository.GetById(idSpec, mapperDto);
        return ipra;
    }

    
}