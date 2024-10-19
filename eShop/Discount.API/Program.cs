using Discount.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Discount.BLL.MappingProfile;
using Discount.API.MappingProfile;
using Discount.DAL.Repositories.Contract;
using Discount.DAL.Repositories;
using Discount.BLL.Services.Contract;
using Discount.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region Dependencies
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<ICouponService, CouponService>();
#endregion
#region DbContext
builder.Services.AddDbContext<DiscountDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Discount.DAL"), optionBuilder =>
    {
        optionBuilder.MigrationsAssembly("Discount.DAL");
    });
});
#endregion
#region Automapper
builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddProfile(new APIMappingProfile());
    configuration.AddProfile(new BLLMappingProfile());
});
#endregion
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
