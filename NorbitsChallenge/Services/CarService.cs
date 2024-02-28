using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorbitsChallenge.Helpers;
using NorbitsChallenge.Models.Contracts;
using NorbitsChallenge.Models.Db;
using NorbitsChallenge.Models.Dto;

namespace NorbitsChallenge.Services;

public class CarService : ICarService
{
    private readonly IWorkshopRepository<Car> _cars;
    private readonly int _companyId;

    public CarService(IWorkshopRepository<Car> cars)
    {
        _cars = cars;
        _companyId = UserHelper.GetLoggedOnUserCompanyId();
    }

    public async Task<int> GetTireCount(string licensePlate)
    {
        var car = await _cars
            .GetAll()
            .FirstOrDefaultAsync(o => o.CompanyId == _companyId && o.LicensePlate == licensePlate);

        return car.TireCount;
    }

    public async Task<List<CarDto>> GetCompanyCars()
    {
        return await _cars.GetAll()
            .Where(o => o.CompanyId == _companyId)
            .Select(o => new CarDto
            {
                LicensePlate = o.LicensePlate,
                Description = o.Description,
                Model = o.Model,
                Brand = o.Brand,
                TireCount = o.TireCount
            })
            .ToListAsync();
    }

    public async Task<CarDto> GetCarDetails(string licensePlate)
    {
        var car = await _cars
            .GetAll()
            .Where(o => o.CompanyId == _companyId)
            .FirstOrDefaultAsync(o => o.LicensePlate == licensePlate);

        return new CarDto
        {
            LicensePlate = car.LicensePlate,
            Description = car.Description,
            Model = car.Model,
            Brand = car.Brand,
            TireCount = car.TireCount
        };
    }

    public async Task UpdateCar(string licensePlate, CarDto carDto)
    {
        var car = await _cars
            .GetAll()
            .Where(o => o.CompanyId == _companyId)
            .FirstOrDefaultAsync(o => o.LicensePlate == licensePlate);
        
        car.Description = carDto.Description;
        car.LicensePlate = carDto.LicensePlate;
        car.Brand = carDto.Brand;
        car.TireCount = carDto.TireCount;
        car.Model = carDto.Model;
        
        await _cars.UpdateAsync(car);
    }

    public async Task AddCar(CarDto carDto)
    {
        var car = new Car
        {
            LicensePlate = carDto.LicensePlate,
            Description = carDto.Description,
            Model = carDto.Model,
            Brand = carDto.Brand,
            TireCount = carDto.TireCount,
            CompanyId = UserHelper.GetLoggedOnUserCompanyId()
        };

       await _cars.AddAsync(car);
    }

    public async Task DeleteCar(string licensePlate)
    {
        var car = await _cars
            .GetAll()
            .Where(o => o.CompanyId == _companyId)
            .FirstOrDefaultAsync(o => o.LicensePlate == licensePlate);

        await _cars.DeleteAsync(car);
    }
}