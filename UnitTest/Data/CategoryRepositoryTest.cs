using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using UnitTest.Helpers;

namespace UnitTest.Data;

public class CategoryRepositoryTest
{
    AppDbContext dbContext;
    IUnitOfWork unitOfWork;

    [SetUp]
    public void Setup()
    {
        dbContext = DbContextHelper.GetDbContext();
        unitOfWork = DbContextHelper.GetUnitOfWork();
    }

    [Test]
    [TestCase("Test2")]
    [TestCase("Test3")]
    [TestCase("Test4")]
    [TestCase("Test5")]
    [TestCase("Test6")]
    [TestCase("Test7")]
    public async Task AddAsync(string name)
    {
        var category = new Category() { Name = name, Description = "Test uchun" };
        await unitOfWork.Category.CreateAsync(category);
        var result = await dbContext.Categories.FirstOrDefaultAsync(p => p.Name == name);
        Assert.That(category.Name, Is.EqualTo(result!.Name));
    }



    [TearDown]
    public void Teardown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
