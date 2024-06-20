using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories;

public class OrderDetailRepository(AppDbContext dbContext) : GenericRepository<OrderDetail>(dbContext), IOrderDetalRepository
{
}
