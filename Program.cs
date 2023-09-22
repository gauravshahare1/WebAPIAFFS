using WebAPIAFFS.DAL.DBContext1;
using Microsoft.EntityFrameworkCore;
using AAFS.BAL.IService;
using AAFS.BAL.Service;
using WebAPIAFFS.DAL.IRepositories;
using WebAPIAFFS.DAL.Repositories;
using WebAPIAFFS.BAL.IServices;
using WebAPIAFFS.BAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("abcde"),
    //options => options.CommandTimeout(999)
    options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null)
), ServiceLifetime.Transient);

//Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IDistrictService, DistrictService>();

//Repositories
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IDistrictRepository, DistrictRepository>();








var app = builder.Build();

//Database Connection

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
