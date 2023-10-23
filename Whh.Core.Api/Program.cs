using SqlSugar.IOC;
using Whh.Core.IRepository;
using Whh.Core.IServices;
using Whh.Core.Repository;
using Whh.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// 依赖注入
builder.Services.AddCustomIOC();

//连接数据库
builder.Services.AddSqlSugar(new IocConfig()
{
    ConnectionString = builder.Configuration.GetConnectionString("SQLite"),
    DbType = IocDbType.Sqlite,
    IsAutoCloseConnection = true,
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


public static class IOCExtend
{
    public static IServiceCollection AddCustomIOC(this IServiceCollection services)
    {
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IBlogService, BlogService>();
        return services;
    }
}