using ApiAdminShop.Configuration;
using Application.Common.Mapper;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Data.DbContexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IAccountService,AccountService>();
builder.Services.AddTransient<IAdminService,AdminService>();
builder.Services.AddTransient<IAuthManager,AuthManager>();
builder.Services.AddTransient<ICategoryService,CategoryService>();  
builder.Services.AddTransient<IEmailService,EmailService>();
builder.Services.AddTransient<IOrderDetailsService,OrderDetailService>();
builder.Services.AddTransient<IOrdersService,OrdersService>();
builder.Services.AddTransient<IProductService,ProductService>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IReportService,ReportService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureJwtAuthorize(builder.Configuration);
builder.Services.ConfigureSwaggerAuthorize(builder.Configuration);

builder.Services.AddMemoryCache();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();