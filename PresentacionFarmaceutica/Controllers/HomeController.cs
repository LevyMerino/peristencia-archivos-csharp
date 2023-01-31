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



            return View();
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