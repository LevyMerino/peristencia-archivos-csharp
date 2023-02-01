using MedicamentContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PresentacionFarmaceutica.Models;
using System.Diagnostics;
using System.Globalization;

namespace PresentacionFarmaceutica.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MedicamentFile medicamentFile;
        private readonly PharmaceuticalFormFile pharmaceuticalFormFile;
        IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration confi)
        {
            _logger = logger;
            _configuration = confi;
            medicamentFile = new(_configuration.GetValue<String>("ConnectionStrings:FileConnection") + "Medicamentos.txt");
            pharmaceuticalFormFile = new(_configuration.GetValue<String>("ConnectionStrings:FileConnection") + "FormaFarmaceutica.txt");
        }

        public IActionResult Index(string SearchString)
        {

            medicamentFile.Read();
            pharmaceuticalFormFile.Read();

            List<DataMedicament>? medicaments = medicamentFile.Elements;
            List<DataPharmaceuticalForm>? pharmaceuticalForms = pharmaceuticalFormFile.Elements;

            var presentation = from m in medicaments
                               join p in pharmaceuticalForms
                               on m.IdFormaFamamaceutica equals p.Id
                               select new
                               {
                                   Id = m.Id,
                                   Nombre = m.Nombre,
                                   Concentracion = m.Concentracion,
                                   FormaFamamaceutica = p.Nombre,
                                   Precio = m.Precio,
                                   Stock = m.Stock,
                                   Presentacion = m.Presentacion,
                                   Habilitado = m.Habilitado,
                               };

            if (!String.IsNullOrEmpty(SearchString))
            {
                presentation = presentation.Where(item => item.Nombre == SearchString);
            }

            var sesion = GetSessionInfo();

            if (sesion is not null)
            {
                if (!string.IsNullOrEmpty(sesion.First()))
                {
                    ViewBag.isLogged = true;
                }
                else
                {
                    ViewBag.isLogged = false;
                }
            }

            return View(presentation.ToList());
        }


        [HttpGet]
        public IActionResult EditView(int id)
        {
            DataMedicament medicament = medicamentFile.ReadItem(id);

            pharmaceuticalFormFile.Read();
            List<DataPharmaceuticalForm>? pharmaceuticalForms = pharmaceuticalFormFile.Elements;

            PresentationEditMedicament presentationEditMedicament = new();

            presentationEditMedicament.medicaments.Add(medicament);
            presentationEditMedicament.pharmaceuticalForms = pharmaceuticalForms;

            return View("Edit", presentationEditMedicament);
        }


        [HttpPut]
        public IActionResult EditItem([FromBody] DtoMedicaments dto)
        {

            DataMedicament mediicament = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Concentracion = dto.Concentracion,
                IdFormaFamamaceutica = dto.IdFormaFamamaceutica,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Presentacion = dto.Presentacion,
                Habilitado = dto.Habilitado
            };

            medicamentFile.Editar(dto.Id, mediicament);

            return Json("Ok");
        }

        [HttpGet]
        public IActionResult CreateView()
        {
            pharmaceuticalFormFile.Read();
            List<DataPharmaceuticalForm>? pharmaceuticalForms = pharmaceuticalFormFile.Elements;

            return View("Create", pharmaceuticalForms);
        }


        [HttpPost]
        public IActionResult CreateItem([FromBody] DtoMedicaments dto)
        {

            DataMedicament mediicament = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Concentracion = dto.Concentracion,
                IdFormaFamamaceutica = dto.IdFormaFamamaceutica,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Presentacion = dto.Presentacion,
                Habilitado = dto.Habilitado
            };

            medicamentFile.Agregar(mediicament);

            return Json("Ok");
        }

        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            medicamentFile.Delete(id);
            return Json("Ok");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult LoginView()
        {

            return View("Login");
        }

        [HttpPost]
        public IActionResult Login([FromBody] DtoLogin login)
        {
            UserFile usersFile = new(_configuration.GetValue<String>("ConnectionStrings:FileConnection") + "Usuarios.txt");
            usersFile.Read();


            var users = usersFile.Elements;

            var userAtFile = users.Find(item => item.Usuario == login.User && item.Password == login.Password);

            if (userAtFile is not null)
            {
                SetSessionInfo(userAtFile.Nombre, userAtFile.Usuario);
                return Json(new { success = true, message = "ok" });
            }
            else
            {
                return Json(new { success = false, message = "" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}