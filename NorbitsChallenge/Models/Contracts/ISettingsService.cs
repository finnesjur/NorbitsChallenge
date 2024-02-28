using System.Collections.Generic;
using System.Threading.Tasks;
using NorbitsChallenge.Models.Dto;

namespace NorbitsChallenge.Models.Contracts;

public interface ISettingsService
{
    Task<string> GetCompanyName();
    Task<List<SettingsDto>> GetSettings();
    Task UpdateSetting(SettingsDto setting);
}