using Catalog.API.MappingProfile;
using Catalog.BLL.MappingProfile;
using Catalog.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddProfile(new ApiMappingProfile());
    configuration.AddProfile(new BllMappingProfile());
});
builder.Services.AddDbContext<CatalogDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Catalog.DAL"), optionBuilder =>
    {
        optionBuilder.MigrationsAssembly("Catalog.DAL");
    });
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

app.UseAuthorization();

app.MapControllers();

app.Run();
