using System.Collections.Generic;
using System.Threading.Tasks;
using NorbitsChallenge.Models.Dto;

namespace NorbitsChallenge.Models.Contracts;

public interface ICarService
{
    Task<int> GetTireCount(string licensePlate);
    Task<List<CarDto>> GetCompanyCars();
    Task<CarDto> GetCarDetails(string licencePlate);
    Task UpdateCar(string licensePlate, CarDto carDto);
    Task AddCar(CarDto carDto);
    Task DeleteCar(string licencePlate);
}