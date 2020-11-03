using Abp.AspNetCore.Mvc.Views;

namespace orion.Web.Views
{
    public abstract class orionRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected orionRazorPage()
        {
            LocalizationSourceName = orionConsts.LocalizationSourceName;
        }
    }
}
