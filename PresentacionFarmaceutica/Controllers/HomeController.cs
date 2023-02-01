using MedicamentContext;
using Microsoft.AspNetCore.Mvc;
using PresentacionFarmaceutica.Models;
using System.Diagnostics;

namespace PresentacionFarmaceutica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            MedicamentFile medicamentFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\Medicamentos.txt");
            medicamentFile.Read();

            PharmaceuticalFormFile pharmaceuticalFormFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\FormaFarmaceutica.txt");
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

            return View(presentation);
        }

        [HttpGet]
        public IActionResult EditView(int id)
        {
            MedicamentFile medicamentFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\Medicamentos.txt");
            DataMedicament medicament = medicamentFile.ReadItem(id);

            PharmaceuticalFormFile pharmaceuticalFormFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\FormaFarmaceutica.txt");
            pharmaceuticalFormFile.Read();
            List<DataPharmaceuticalForm>? pharmaceuticalForms = pharmaceuticalFormFile.Elements;

            PresentationEditMedicament presentationEditMedicament = new();

            presentationEditMedicament.medicaments.Add(medicament);
            presentationEditMedicament.pharmaceuticalForms = pharmaceuticalForms;

            return View("Edit",presentationEditMedicament);
        }


        [HttpPut]
        public IActionResult EditItem([FromBody] DtoMedicaments dto)
        {

            MedicamentFile medicamentFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\Medicamentos.txt");

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
            PharmaceuticalFormFile pharmaceuticalFormFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\FormaFarmaceutica.txt");
            pharmaceuticalFormFile.Read();
            List<DataPharmaceuticalForm>? pharmaceuticalForms = pharmaceuticalFormFile.Elements;

            return View("Create",pharmaceuticalForms);
        }


        [HttpPost]
        public IActionResult CreateItem([FromBody] DtoMedicaments dto)
        {

            MedicamentFile medicamentFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\Medicamentos.txt");

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
            MedicamentFile medicamentFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\Medicamentos.txt");
            medicamentFile.Delete(id);
            return Json("Ok");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}