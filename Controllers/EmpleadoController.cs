using Microsoft.AspNetCore.Mvc;

namespace clase00_asp_net.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            //proceso 1
            //proceso 2
            //¿Como pasamos valores del controlador a la vista?
            int carnet = 123;
            ViewBag.ci = carnet;
            ViewBag.nombre = "Chichi Peralta";
            ViewBag.isCasado = false;
            ViewBag.estatura = 1.78;
            ViewBag.fechaContratacion = DateTime.Now;
            return View();
        }
    }
}
