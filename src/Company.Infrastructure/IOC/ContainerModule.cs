using Autofac;

namespace CompanySelf.Infrastructure.IOC
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DbContextModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<QueryModule>();
        }
    }
}