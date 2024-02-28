using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorbitsChallenge.Helpers;
using NorbitsChallenge.Models;
using NorbitsChallenge.Models.Contracts;

namespace NorbitsChallenge.Controllers
{
    public class SettingsController: Controller
    {
        private readonly IConfiguration _config;
        private readonly ISettingsService _settingsService;

        public SettingsController(
            IConfiguration config, 
            ISettingsService settingsService)
        {
            _config = config;
            _settingsService = settingsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new SettingsViewModel();
            var settings = await _settingsService.GetSettings();
            model.Settings = settings;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(SettingsInputModel input)
        {
            _settingsService.UpdateSetting(input.Setting);
            return RedirectToAction("Index", new {companyId = UserHelper.GetLoggedOnUserCompanyId()});
        }
    }
}
