using Autofac;
using Microsoft.EntityFrameworkCore;
using Programminglaboratory.PracowaniaProgramowania.Persistence;
using Module = Autofac.Module;

namespace ProgrammingLaboratory.PracowaniaProgramowania.Domain;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<IUnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.Register(c =>
        {
            var opt = new DbContextOptionsBuilder<ApplicationDbContext>();
            opt.UseSqlServer("Server=db; Database=PracowaniaProgramowania; User=sa; Password=Mb7!W7V*MXtE[4Z9;");

            return new ApplicationDbContext(opt.Options);
        }).AsSelf().InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(Repository<>)).AsImplementedInterfaces();
    }
}