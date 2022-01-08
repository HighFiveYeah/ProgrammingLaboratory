using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Programminglaboratory.PracowaniaProgramowania.Persistence;
using ProgrammingLaboratory.PracowniaProgramowania.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterHandlers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<DbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=db; Database=PracowaniaProgramowania; User=sa; Password=Mb7!W7V*MXtE[4Z9;");
});

var app = builder.Build();

await app.Services.InitiateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();