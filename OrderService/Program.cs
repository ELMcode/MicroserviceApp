using Microsoft.Extensions.Options;
using OrderService.Data;
using OrderService.Repositories;
using OrderService.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB
builder.Services.Configure<OrderDatabaseSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<OrderDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<OrderDatabaseSettings>>().Value);

// Register services
builder.Services.AddScoped<OrderContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService.Services.OrderService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
