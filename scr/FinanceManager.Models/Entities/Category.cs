namespace FinanceManager.Models.Entities;
using FinanceManager.Models.Interfaces;

public class Category : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ParentCategoryId { get; set; }
}