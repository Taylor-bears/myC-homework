using Microsoft.EntityFrameworkCore;
using 订单管理;

var builder = WebApplication.CreateBuilder(args);

// 添加控制器支持
builder.Services.AddControllers();

// 注册数据库上下文
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 25)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()));

// 注册 OrderService
builder.Services.AddScoped<OrderService>();

// 添加 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 配置 HTTP 请求管道
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 自动创建数据库
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OrderContext>();
    context.Database.EnsureCreated();
}

app.Run();