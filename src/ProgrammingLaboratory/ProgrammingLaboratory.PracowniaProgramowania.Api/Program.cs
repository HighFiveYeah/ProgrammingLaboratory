using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain;
using ProgrammingLaboratory.PracowniaProgramowania.Api;

var builder = WebApplication.CreateBuilder(args);

//Configure
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<ApplicationModule>();
});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterHandlers();

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