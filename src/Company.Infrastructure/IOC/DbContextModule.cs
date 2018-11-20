using Autofac;
using CompanySelf.Infrastructure.Context;

namespace CompanySelf.Infrastructure.IOC
{
    public class DbContextModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
        }
    }
}