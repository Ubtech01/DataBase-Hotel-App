using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
