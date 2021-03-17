using System.Configuration;
using System.Web.Mvc;

namespace KeyVaultAuthDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ViewBag.Body = ConfigurationManager.AppSettings["DocumentDbUrl"];

            return View();
        }
    }
}
