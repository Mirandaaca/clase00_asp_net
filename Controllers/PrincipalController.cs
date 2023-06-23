using Microsoft.AspNetCore.Mvc;

namespace clase00_asp_net.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
