using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FullName = "Ozodbek Umarov",
                Email = "ozodchik.krasavchik@gmail.com",
                Gender = Gender.Male,
                isVerified = true,
                Salt = "6fed1e40-b4a5-4cec-97b7-9de3970600c2",
                Password = "186cf774c97b60a1c106ef718d10970a6a06e06bef89553d9ae65d938a886eae",
                Role = Role.SuperAdmin
            });
    }
}