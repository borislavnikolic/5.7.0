using Microsoft.AspNetCore.Mvc;

namespace orion.Web.Controllers
{
    public class HomeController : orionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}