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

            PharmaceuticalFormFile  pharmaceuticalFormFile = new(@"C:\Users\MSI-PRO\Downloads\Prueba Desarollador\Prueba Desarollador\Prueba Desarollador\FormaFarmaceutica.txt");
            pharmaceuticalFormFile.Read();

            List<DataMedicament> medicaments = new();
            medicaments = medicamentFile.Elements;

            List<DataPharmaceuticalForm> pharmaceuticalForms = new();
            pharmaceuticalForms = pharmaceuticalFormFile.Elements;

            //List<PresentationMedicament> presentations = new();

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