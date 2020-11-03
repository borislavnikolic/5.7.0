using System.Threading.Tasks;
using orion.Web.Controllers;
using Shouldly;
using Xunit;

namespace orion.Web.Tests.Controllers
{
    public class HomeController_Tests: orionWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
