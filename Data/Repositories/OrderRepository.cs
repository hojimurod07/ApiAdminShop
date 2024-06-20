using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories;

public class OrderRepository(AppDbContext dbContext) : GenericRepository<Order>(dbContext), IOrderRepository
{
}
