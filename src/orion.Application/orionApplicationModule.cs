using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace orion
{
    [DependsOn(
        typeof(orionCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class orionApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(orionApplicationModule).GetAssembly());
        }
    }
}