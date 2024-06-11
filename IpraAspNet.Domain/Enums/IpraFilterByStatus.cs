using System.ComponentModel.DataAnnotations;

namespace IpraAspNet.Domain.Enums;

public enum IpraFilterByStatus
{
    [Display(Name = "Все")] NoFilter = 0,
    [Display(Name = "Открытые")] ByOpen,
    [Display(Name = "В работе")] ByWork,
    [Display(Name = "Отработанные")] BySpent,
    [Display(Name = "Закрытые")] ByClose
}