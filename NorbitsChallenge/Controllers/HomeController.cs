using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorbitsChallenge.Helpers;
using NorbitsChallenge.Models;
using NorbitsChallenge.Models.Contracts;

namespace NorbitsChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ICarService _carService;
        private readonly ISettingsService _settingsService;

        public HomeController(
            IConfiguration config, 
            ICarService carService, 
            ISettingsService settingsService)
        {
            _config = config;
            _carService = carService;
            _settingsService = settingsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await GetCompanyModel();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

        private async Task<HomeModel> GetCompanyModel()
        {
            var companyId = UserHelper.GetLoggedOnUserCompanyId();
            
            var companyName = await _settingsService.GetCompanyName();
            var cars = await _carService.GetCompanyCars();
            return new HomeModel { CompanyId = companyId, CompanyName = companyName, CompanyCars = cars};
        }
    }
}
