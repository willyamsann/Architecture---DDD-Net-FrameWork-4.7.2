using System.Web.Mvc;

namespace Arquitetura.UI.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}