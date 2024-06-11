using System.ComponentModel.DataAnnotations;

namespace IpraAspNet.Domain.Enums;

public enum IpraFilterByEndless
{
    [Display(Name = "Все")] NoFilter = 0,
    [Display(Name = "Срок истекает")] Expiring,
    [Display(Name = "С датой оканчания")] WithEndDate,
    [Display(Name = "Без даты окончания")] Indefinitely
}