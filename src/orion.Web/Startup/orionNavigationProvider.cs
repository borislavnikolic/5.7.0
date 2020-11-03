using Abp.Application.Navigation;
using Abp.Localization;

namespace orion.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class orionNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                /*.AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home"
                        )
                )AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "Home/About",
                        icon: "fa fa-info"
                        )
                )*/.AddItem
                (
                   new MenuItemDefinition
                   (
                     PageNames.Package,
                     L("PckagePage"),
                     url:"Package/Index",
                     icon:"fa fa-home")
                 ).AddItem
                (
                   new MenuItemDefinition
                   (
                     PageNames.Concract,
                     L("ConcractPage"),
                     url: "Concract/Index",
                     icon: "fa fa-address-card-o")
                 );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, orionConsts.LocalizationSourceName);
        }
    }
}
