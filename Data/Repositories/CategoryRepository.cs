using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories;

public class CategoryRepository(AppDbContext dbContext) : GenericRepository<Category>(dbContext), ICategoryRepository
{
}
