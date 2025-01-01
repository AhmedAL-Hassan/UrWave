using Microsoft.EntityFrameworkCore;

using UrWave.Application.DI;
using UrWave.Infrastructure;
using UrWave.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

AddDataBaseServices(builder.Services, builder.Configuration);
AddAppServices(builder.Services, builder.Configuration);
ConfigureAutoMapper(builder.Services);

builder.Services.AddControllers();
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

static void AddAppServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddInfrastructureServices();
    services.AddApplicationServices();
}

static void AddDataBaseServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<UrWaveContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
}

static void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(typeof(Program)); 
}