using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace orion.EntityFrameworkCore
{
    [DependsOn(
        typeof(orionCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class orionEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(orionEntityFrameworkCoreModule).GetAssembly());
        }
    }
}