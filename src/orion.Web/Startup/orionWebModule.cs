using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using orion.Configuration;
using orion.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace orion.Web.Startup
{
    [DependsOn(
        typeof(orionApplicationModule), 
        typeof(orionEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class orionWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public orionWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(orionConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<orionNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(orionApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(orionWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(orionWebModule).Assembly);
        }
    }
}