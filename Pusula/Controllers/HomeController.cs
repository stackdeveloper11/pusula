using System.Web.Mvc;

namespace Pusula.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult BenimUlkem()
        {
            return View();
        }
        public ActionResult UlkelerListesi(int id=0)
        {
            return View();
        }
        public ActionResult Uyelik()
        {
            return View();
        }

    }
}