using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Webgentle.BookStore.Data;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
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