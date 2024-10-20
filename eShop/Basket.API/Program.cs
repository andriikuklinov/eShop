using Basket.API.MappingProfiles;
using Basket.BLL.MappingProfiles;
using Basket.BLL.Services;
using Basket.BLL.Services.Contract;
using Basket.DAL.Repositories;
using Basket.DAL.Repositories.Contract;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Dependencies
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
#endregion
#region Automapper
builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddProfile(new ApiMappingProfile());
    configuration.AddProfile(new BllMappingProfile());
});
#endregion
#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion
#region Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});
#endregion
#region MassTransit and RabbitMQ
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((context, configuration) =>
    {
        configuration.Host(builder.Configuration.GetValue<string>("EventBusSettings:Host"));
    });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
