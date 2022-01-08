using Programminglaboratory.PracowaniaProgramowania.Persistence;

namespace ProgrammingLaboratory.PracowniaProgramowania.Api;

public static class Extensions
{
    public static async Task InitiateDatabase(this IServiceProvider serviceProvider)
    {
        using var scope =  serviceProvider.CreateScope();
        await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        await dbContext.Database.EnsureCreatedAsync();
    }
    
    public static async Task RegisterCommandHandlers(this IServiceCollection serviceCollection)
    {
    }
}