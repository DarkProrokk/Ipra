// using Xunit;
// using IpraAspNet.Domain.Entities;
//
// using IpraAspNet.Application.IpraService;
// using IpraAspNet.Application.IpraService.QueryObject;
// using IpraAspNet.Domain.Enums;
//
//
// namespace Tests;
//
// public class IpraDtoTest()
// {
//     IQueryable<Ipra> _ipraList = new List<Ipra>
//     {
//         new Ipra { id = 1, Number = "123", PatientNameMse = "John", PatientSurnameMse = "Doe", PatientLastnameMse = "Smith", PatientSnilsMse = "1234567890", SectorName = "Sector 1", PatientBirthdayMse = "02.11.2001", Mo = new MO { Shortname = "MO1" }, StatusId = 1, IssueDate = DateOnly.MaxValue, EndDate = DateOnly.MaxValue, Reports = new List<Report>(), IsEndless = false, GuidMse = "as1231"},
//         new Ipra { id = 2, Number = "456", PatientNameMse = "Jane", PatientSurnameMse = "Doe", PatientLastnameMse = "Smith", PatientSnilsMse = "1234567890", SectorName = "Sector 2", PatientBirthdayMse = "02.11.2001", Mo = new MO { Shortname = "MO2" }, StatusId = 2, IssueDate = DateOnly.MaxValue, EndDate = null, Reports = new List<Report>(), IsEndless = true, GuidMse = "as1231" }
//     }.AsQueryable();
//     
//     IQueryable<IpraListDto> _expectedDtoList = new List<IpraListDto>
//     {
//         new IpraListDto { id = 1, Number = "123", FirstName = "John", Surname = "Doe", Patronymic = "Smith", Snils = "1234567890", Sector = "Sector 1", BirthDate = "02.11.2001", MoShortName = "MO1", StatusId = 1, StartDate = DateOnly.MaxValue, EndDate = DateOnly.MaxValue, Report = new List<Report>(), IsEndless = false },
//         new IpraListDto { id = 2, Number = "456", FirstName = "Jane", Surname = "Doe", Patronymic = "Smith", Snils = "1234567890", Sector = "Sector 2", BirthDate = "02.11.2001", MoShortName = "MO2", StatusId = 2, StartDate = DateOnly.MaxValue, EndDate = null, Report = new List<Report>(), IsEndless = true }
//     }.AsQueryable();
//
//     [Fact]
//     public void TestIpraMapToDto()
//     {
//         var queryResult = _ipraList.MapIpraToDto();
//         Assert.Equivalent(_expectedDtoList, queryResult);
//     }
//
//     [Fact]
//     public void TestIpraFilterByStatusEqual()
//     {
//         var queryResult = _ipraList.MapIpraToDto();
//         var expectedResult = _expectedDtoList.Where(i => i.StatusId == 1);
//         Assert.Equivalent(expectedResult, queryResult);
//     }
//
//     [Fact]
//     public void TestIpraFilterByWithEndlessEqual()
//     {
//         var queryResult = _ipraList.MapIpraToDto().FilterIpraByEndless(IpraFilterByEndless.WithEndDate);
//         var expectedResult = _expectedDtoList.Where(i => i.IsEndless == false);
//         Assert.Equivalent(expectedResult, queryResult);
//     }
//     
//     [Fact]
//     public void TestIpraFilterByNotEndlessEqual()
//     {
//         var queryResult = _ipraList.MapIpraToDto().FilterIpraByEndless(IpraFilterByEndless.Indefinitely);
//         var expectedResult = _expectedDtoList.Where(i => i.IsEndless == true);
//         Assert.Equivalent(expectedResult, queryResult);
//     }
// }