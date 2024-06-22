using Domain.Entities;

namespace Data.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<List<Order>> GetAllOrdersAsync();
}
