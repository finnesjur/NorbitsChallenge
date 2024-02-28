using System.ComponentModel.DataAnnotations;

namespace NorbitsChallenge.Models.Db;

public class Car
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string LicensePlate { get; set; }
    
    [MaxLength(50)]
    public string Description { get; set; }
    
    [MaxLength(50)]
    public string Model { get; set; }
    
    [MaxLength(50)]
    public string Brand { get; set; }
    
    public int TireCount { get; set; }
    public int CompanyId { get; set; }
}