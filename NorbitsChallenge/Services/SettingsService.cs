using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorbitsChallenge.Helpers;
using NorbitsChallenge.Models.Contracts;
using NorbitsChallenge.Models.Db;
using NorbitsChallenge.Models.Dto;

namespace NorbitsChallenge.Services;

public class SettingsService : ISettingsService
{
    private readonly IWorkshopRepository<Settings> _settings;
    const string CompanyName = "companyName";
    private readonly int _companyId;

    public SettingsService(IWorkshopRepository<Settings> settings)
    {
        _settings = settings;
        _companyId = UserHelper.GetLoggedOnUserCompanyId();
    }

    public async Task<string> GetCompanyName()
    {
        var companyName = await _settings.GetAll()
            .Where(o => o.Setting == CompanyName)
            .FirstOrDefaultAsync(o => o.CompanyId == _companyId);

        return companyName?.SettingValue;
    }

    public async Task<List<SettingsDto>> GetSettings()
    {
        return await _settings.GetAll()
            .Where(o => o.CompanyId == _companyId)
            .Select(o => new SettingsDto
            {
                Key = o.Setting,
                Value = o.SettingValue,
            })
            .ToListAsync();
    }

    public async Task UpdateSetting(SettingsDto setting)
    {
        var settingsList = _settings
            .GetAll()
            .Where(o => o.CompanyId == _companyId)
            .Where(o => o.Setting == setting.Key)
            .ToList();

        settingsList.ForEach(o => o.SettingValue = setting.Value);
        await _settings.UpdateRangeAsync(settingsList);
    }
}