namespace FsxWeb.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Position Visualizer";

            return View();
        }
    }
}
