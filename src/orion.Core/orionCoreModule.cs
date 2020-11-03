using Abp.Modules;
using Abp.Reflection.Extensions;
using orion.Localization;

namespace orion
{
    public class orionCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            orionLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(orionCoreModule).GetAssembly());
        }
    }
}