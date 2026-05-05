namespace FinanceManager.Models.Entities;
using FinanceManager.Models.Interfaces;
using FinanceManager.Models.Enums;

public class Transaction : IEntity
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public string Comment { get; set; }
    public Guid CategoryId { get; set; }
}