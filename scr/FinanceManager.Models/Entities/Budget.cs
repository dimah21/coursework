namespace FinanceManager.Models.Entities;
using FinanceManager.Models.Interfaces;
public class Budget : IEntity
{
    public Guid Id { get; set; }
    public decimal LimitAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid CategoryId { get; set; }
}