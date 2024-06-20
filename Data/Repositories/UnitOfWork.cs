using Data.DbContexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;
    public ICategoryRepository Category => new CategoryRepository(_dbContext);

    public IOrderDetalRepository OrderDetal => new OrderDetailRepository(_dbContext);

    public IOrderRepository Order => new OrderRepository(_dbContext);

    public IProductRepository Product => new ProductRepository(_dbContext);

    public IUserRepository User => new UserRepository(_dbContext);
}
