using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.WebMVC.Controllers
{
    public class ExpertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
