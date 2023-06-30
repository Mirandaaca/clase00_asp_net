using clase00_asp_net.Models;
using Microsoft.AspNetCore.Mvc;

namespace clase00_asp_net.Controllers
{
    [Route("empleado")]
    public class EmpleadoController : Controller
    {
        private IConfiguration configuration;
        public EmpleadoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        //La Vista que se llamara en la accion o metodo debe tener exactamente el mismo nombre que el metodo. Fijarse en la carpeta Views, el html (la vista) tiene el mismo nombre que este metodo
        //Pero tambien se puede codificar para que no tenga le mismo nombre, para no estar atados al nombre del metodo, fijarse la linea 85
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            //proceso 1
            //proceso 2
            //¿Como pasamos valores del controlador a la vista?
            //El ViewBag seria como un bolsillo o contenedor donde se almacenan valores, objetos, y otras cosas para posteriormente
            //mostrarse en la Vista
            int carnet = 123;
            ViewBag.ci = carnet;
            ViewBag.nombre = "Chichi Peralta";
            ViewBag.isCasado = false;
            ViewBag.estatura = 1.78;
            ViewBag.fechaContratacion = DateTime.Now;

            //Pasandole un objeto Empleado a la Vista

            var emp = new Empleado {

                ci = 3391,
                nombre = "Chichi Peralta",
                estatura = 1.82,
                peso = 85,
                foto = "puerta.jpg"
            };
            ViewBag.empleado = emp;

            //Pasandole varios objetos en una lista a la Vista
            var emps = new List<Empleado>
            {
                new Empleado
                {
                    ci = 3954,
                    nombre = "Huanca Mamani",
                    estatura = 1.56,
                    peso = 65,
                    foto = "x.png"
                },
                new Empleado
                {
                    ci = 3331,
                    nombre = "Huanca Zurita",
                    estatura = 1.76,
                    peso = 96,
                    foto = "descarga.jpg"
                },
                new Empleado
                {
                    ci = 3279,
                    nombre = "Sanchez Cuellar",
                    estatura = 1.65,
                    peso = 120,
                    foto = "puerta.jpg"
                }
            };
            ViewBag.empleados = emps;

            return View();
        }
        [Route("detalles")]
        [Route("detallazos")]
        //Creando otro metodo o accion
        public IActionResult Ejemplo1()
        {
            ViewBag.variable1 = configuration["Texto"];
            ViewBag.variable2 = configuration["VariablesConfig:var1"];
            ViewBag.variable3 = configuration["VariablesConfig:var2"];
            ViewBag.variable4 = configuration["VariablesConfig:var3"];
            ViewBag.variable5 = configuration["VariablesConfig:varx:default"];
            ViewBag.variable6 = configuration["VariablesConfig:varx:advanced:extremo"];
            return View("Configuraciones"); //retornando/devolviendo la vista, de esta manera la vista no necesariamente debe tener el mismo nombre que el metodo
        }
        //recibir un parametro por ruta
        [Route("editar/{ci}")] //podia haber sido [Route("EjemploParametro/{ci}")]
        public IActionResult EjemploParametro(int ci)
        {
            ViewBag.carnet = ci;
            /*if(ci == null)
            {
                return View("ErrorSinCI"); //retornar una vista bonita en caso de no encontrar ese parametro
            }*/
            return View();
        }
        [Route("editar2/{ci}/{apellido}")]
        public IActionResult EjemploParametro2(int ci, string apellido)
        {
            ViewBag.carnet = ci;
            ViewBag.apellido = apellido;
            return View("EjemploParametro"); //de esta manera ya no tenemos que crear otra vista para este metodo, sino que se redirigira a EjemploParametro.cshtml
        }
        //Query String
        [Route("editar3")]
        public IActionResult EjemploParametro3([FromQuery(Name = "ci")] int ci)
        {
            ViewBag.carnet = ci;
            return View("EjemploParametro");
        }

        [Route("editar4")]
        public IActionResult EjemploParametro4([FromQuery(Name = "ci")] int ci, [FromQuery(Name = "ap")] string apellido)
        {
            ViewBag.carnet = ci;
            ViewBag.apellido = apellido;
            return View("EjemploParametro");
        }
    }
}
