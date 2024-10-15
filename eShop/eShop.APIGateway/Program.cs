using eShop.Aggregator.Contracts;
using eShop.Aggregator.Services;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOcelot().AddCacheManager(settings=>
{
    settings.WithDictionaryHandle();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);
#region DI Services
builder.Services.AddHttpClient<ICatalogService, CatalogService>(config=> config.BaseAddress = new Uri(builder.Configuration["ApiSettings:CatalogURL"]));
builder.Services.AddHttpClient<IBasketService, BasketService>(config => config.BaseAddress = new Uri(builder.Configuration["ApiSettings:BasketURL"]));
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
await app.UseOcelot();
app.Run();
