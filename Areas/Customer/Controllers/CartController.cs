using Microsoft.AspNetCore.Mvc;

namespace group_web_application_security.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
