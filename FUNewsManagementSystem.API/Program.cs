using FUNewsManagementSystem.Application.Services;
using FUNewsManagementSystem.Infrastructure.Data;
using FUNewsManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var sqlServerAuthConnection = builder.Configuration.GetConnectionString("DefaultConnection")
    .Replace("${MY_SQL_USR}", Environment.GetEnvironmentVariable("MY_SQL_USR") ?? "")
    .Replace("${MY_SQL_PWD}", Environment.GetEnvironmentVariable("MY_SQL_PWD") ?? "");
// Add services to the container.


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<INewsArticleRepository, NewsArticleRepository>();
builder.Services.AddScoped<INewsArticleService, NewsArticleService>();

builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(sqlServerAuthConnection));

builder.Services.AddControllers().AddOData(opt => opt.Select().Filter().OrderBy());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
