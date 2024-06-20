using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories;

public class ProductRepository(AppDbContext dbContext) : GenericRepository<Product>(dbContext), IProductRepository
{
}
