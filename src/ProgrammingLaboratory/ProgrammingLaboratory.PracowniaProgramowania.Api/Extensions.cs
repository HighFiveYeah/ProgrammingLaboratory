using Microsoft.EntityFrameworkCore;
using Programminglaboratory.PracowaniaProgramowania.Persistence;

namespace ProgrammingLaboratory.PracowniaProgramowania.Api;

public static class Extensions
{
    public static void InitiateDatabase(this IServiceProvider serviceProvider)
    {
        using var scope =  serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // var sp = (dbContext as IInfrastructure<IServiceProvider>).Instance;
        //
        // var modelDiffer = sp.GetRequiredService<IMigrationsModelDiffer>();
        // var migrationsAssembly = sp.GetRequiredService<IMigrationsAssembly>();
        // var dependencies = sp.GetRequiredService<ProviderConventionSetBuilderDependencies>();
        // var relationalDependencies = sp.GetRequiredService<RelationalConventionSetBuilderDependencies>();
        //
        // var typeMappingConvention = new TypeMappingConvention(dependencies);
        // typeMappingConvention.ProcessModelFinalizing(
        //     ((IConventionModel) migrationsAssembly.ModelSnapshot.Model).Builder, null);
        //
        // var relationalModelConvention = new RelationalModelConvention(dependencies, relationalDependencies);
        // var sourceModel = relationalModelConvention.ProcessModelFinalized(migrationsAssembly.ModelSnapshot.Model);
        //
        // var diffsExist = modelDiffer.HasDifferences(
        //     ((IMutableModel) sourceModel).FinalizeModel().GetRelationalModel(),
        //     dbContext.Model.GetRelationalModel());
        //
        // if (diffsExist)
        //     throw new InvalidOperationException(
        //         "There are differences between the current database model and the most recent migration.");

        dbContext.Database.Migrate();
    }
}