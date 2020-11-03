using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using orion.Web.Startup;
namespace orion.Web.Tests
{
    [DependsOn(
        typeof(orionWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class orionWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(orionWebTestModule).GetAssembly());
        }
    }
}