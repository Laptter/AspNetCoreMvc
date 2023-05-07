using Microsoft.AspNetCore.Mvc;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("open");
        }
    }
}
