using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.MappingProfile;
using Order.BLL.EventBusConsumer;
using Order.BLL.MappingProfile;
using Order.BLL.Services;
using Order.BLL.Services.Contract;
using Order.DAL.DataContext;
using Order.DAL.Repositories;
using Order.DAL.Repositories.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region Dependencies
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion
#region Automapper
builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddProfile(new ApiMappingProfile());
    configuration.AddProfile(new BllMappingProfile());
});
#endregion
#region DbContext
builder.Services.AddDbContext<OrderDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Order.DAL"), optionBuilder =>
    {
        optionBuilder.MigrationsAssembly("Order.DAL");
    });
});
#endregion
#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion
#region MassTransit and RabbitMQ
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketCheckoutConsumer>();
    config.UsingRabbitMq((context, configuration) =>
    {
        configuration.Host(builder.Configuration.GetValue<string>("EventBusSettings:Host"));
        configuration.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
        {
            c.ConfigureConsumer<BasketCheckoutConsumer>(context);
        });
    });
});
//builder.Services.AddMassTransitHostedService();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
