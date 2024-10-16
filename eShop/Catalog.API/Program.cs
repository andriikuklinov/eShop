using Catalog.API.MappingProfile;
using Catalog.BLL.MappingProfile;
using Catalog.BLL.Services;
using Catalog.BLL.Services.Contract;
using Catalog.DAL.DataContext;
using Catalog.DAL.Repositories;
using Catalog.DAL.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region Dependencies
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
#endregion
#region Automapper
builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddProfile(new ApiMappingProfile());
    configuration.AddProfile(new BllMappingProfile());
});
#endregion
#region DbContext
builder.Services.AddDbContext<CatalogDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Catalog.DAL"), optionBuilder =>
    {
        optionBuilder.MigrationsAssembly("Catalog.DAL");
    });
});
#endregion
#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/catalog/swagger.json", "Catalog API v1");
    });
}

app.MapControllers();

app.Run();
