using Microsoft.EntityFrameworkCore;
using Sithec2023.Models;
using Sithec2023.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// ADD CONTEXT
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

//automapper
builder.Services.AddAutoMapper(typeof(Program));

//Add services
builder.Services.AddScoped<IHumanoRepository, HumanoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

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
