using Abp.Application.Services;

namespace orion
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class orionAppServiceBase : ApplicationService
    {
        protected orionAppServiceBase()
        {
            LocalizationSourceName = orionConsts.LocalizationSourceName;
        }
    }
}