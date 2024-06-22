using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class OrderRepository(AppDbContext dbContext) : GenericRepository<Order>(dbContext), IOrderRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        var orders =  await _dbContext.Orders.ToListAsync();
        return orders;
    }
}
