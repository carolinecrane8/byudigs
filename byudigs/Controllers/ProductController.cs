using Microsoft.AspNetCore.Mvc;

namespace byudigs.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}