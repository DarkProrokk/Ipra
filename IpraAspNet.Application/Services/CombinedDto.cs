// using IpraAspNet.Application.Interfaces;
// using IpraAspNet.Domain.QueryObjects.Interfaces;
//
// namespace IpraAspNet.Application.Services;
//
// public class CombinedDto<TModel>(IEnumerable<TModel> ipraList): ICombinedDto<TModel> where TModel : class
// {
//
//     public IEnumerable<TModel> Data { get;} = ipraList;
//
//     public virtual Dictionary<string, string> HeadersList { get; } = GetHeaders();
//     /// <summary>
//     /// Используется для построения таблицы в <seealso cref="http://127.0.0.1:5001/Home/Test"/>
//     /// </summary>
//     public static Dictionary<string, string> GetHeaders() => new();
//
// }