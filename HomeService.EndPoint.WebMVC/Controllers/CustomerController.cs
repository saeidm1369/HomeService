using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
