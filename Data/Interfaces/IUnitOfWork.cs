namespace Data.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IOrderDetalRepository OrderDetal { get; }
    IOrderRepository Order { get; }
    IProductRepository Product { get; }
    IUserRepository User { get; }
}
