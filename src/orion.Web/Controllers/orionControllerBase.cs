using Abp.AspNetCore.Mvc.Controllers;

namespace orion.Web.Controllers
{
    public abstract class orionControllerBase: AbpController
    {
        protected orionControllerBase()
        {
            LocalizationSourceName = orionConsts.LocalizationSourceName;
        }
    }
}