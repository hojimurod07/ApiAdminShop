using Data.Entities;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public double Price { get; set; }
    public Status Status { get; set; } = Status.todo;
    public int Quantity { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();

}