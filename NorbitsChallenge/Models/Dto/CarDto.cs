namespace NorbitsChallenge.Models.Dto;

public class CarDto
{
    public string LicensePlate { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public int TireCount { get; set; }
}