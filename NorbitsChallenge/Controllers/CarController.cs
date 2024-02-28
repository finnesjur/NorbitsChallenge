using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorbitsChallenge.Models.Contracts;
using NorbitsChallenge.Models.Dto;

namespace NorbitsChallenge.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<IActionResult> Details(int companyId, string licencePlate)
    {
        var car = await _carService.GetCarDetails(licencePlate);
        return View(car);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CarDto carDto)
    {
        _carService.AddCar(carDto);
        return Redirect("/Home");
    }

    public IActionResult Delete(string licensePlate)
    {
        _carService.DeleteCar(licensePlate);
        return Redirect("/Home");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string licencePlate)
    {
        var car = await _carService.GetCarDetails(licencePlate);
        return View(car);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string oldLicencePlate, CarDto carDto)
    {
        await _carService.UpdateCar(oldLicencePlate, carDto);
        return Redirect("/Home");
    }
}