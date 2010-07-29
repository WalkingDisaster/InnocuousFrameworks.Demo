using System.Web.Mvc;
using Sage.Controllers.Home;
using Sage.Models.Home;

namespace Sage.Controllers
{
    [HandleError]
    public class HomeController : SageController
    {
        public ActionResult Index()
        {
            return View(ExecuteCommand<Index, HomeIndexViewModel>());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}