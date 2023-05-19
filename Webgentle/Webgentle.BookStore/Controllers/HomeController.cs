using Microsoft.AspNetCore.Mvc;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}