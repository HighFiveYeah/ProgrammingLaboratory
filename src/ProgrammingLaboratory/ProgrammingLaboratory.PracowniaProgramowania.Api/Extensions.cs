using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain.Queries;
using Programminglaboratory.PracowaniaProgramowania.Persistence;

namespace ProgrammingLaboratory.PracowniaProgramowania.Api;

public static class Extensions
{
    public static async Task InitiateDatabase(this IServiceProvider serviceProvider)
    {
        using var scope =  serviceProvider.CreateScope();
        await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        await dbContext.Database.MigrateAsync();
    }
    
    public static IServiceCollection RegisterHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(UpdateUserCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(DeleteUserCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(UserQuery).GetTypeInfo().Assembly);
        
        serviceCollection.AddMediatR(typeof(CreateProductCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(UpdateProductCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(DeleteProductCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(ProductQuery).GetTypeInfo().Assembly);
        
        serviceCollection.AddMediatR(typeof(CreateOrderCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(UpdateOrderCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(DeleteOrderCommand).GetTypeInfo().Assembly);
        serviceCollection.AddMediatR(typeof(OrderQuery).GetTypeInfo().Assembly);
        
        return serviceCollection;
    }
}