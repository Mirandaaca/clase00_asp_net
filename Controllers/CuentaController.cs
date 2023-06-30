using clase00_asp_net.Models;
using Microsoft.AspNetCore.Mvc;

namespace clase00_asp_net.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            var cuentaModelView = new CuentaModelView();
            cuentaModelView.cuenta = new Cuenta()
            {
                id = 123,
                disponible = true,
                genero = "f" //f: femenino, m: masculino
            };
            cuentaModelView.lenguajes = new List<Lenguaje>()
            {
                new Lenguaje()
                {
                    id = "len01",
                    nombre = "C#",
                    tickeado = true,
                },
                new Lenguaje()
                {
                    id = "len02",
                    nombre = "Python",
                    tickeado = false,
                },
                new Lenguaje()
                {
                    id = "len03",
                    nombre = "Java",
                    tickeado = false,
                },
                new Lenguaje()
                {
                    id = "len04",
                    nombre = "C++",
                    tickeado = false,
                }
            };
            var cargos = new List<Cargo>() {
                new Cargo {id = "C01", nombre = "Pasante"},
                new Cargo {id = "C02", nombre = "Auxiliar de desarrollo"},
                new Cargo {id = "C03", nombre = "Programador Senior"},
                new Cargo {id = "C04", nombre = "Jefe de departamento"}
            };
            cuentaModelView.cargos = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cargos, "id", "nombre");
            return View("Index", cuentaModelView);
        }
    }
}
