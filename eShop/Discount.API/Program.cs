using Discount.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region DbContext
builder.Services.AddDbContext<DiscountDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Discount.DAL"), optionBuilder =>
    {
        optionBuilder.MigrationsAssembly("Discount.DAL");
    });
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
