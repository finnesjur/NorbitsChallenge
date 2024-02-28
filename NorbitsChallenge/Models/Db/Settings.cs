using System.ComponentModel.DataAnnotations;

namespace NorbitsChallenge.Models.Db;

public class Settings
{
    [Key]
    [Required]
    public int Id { get; set; }
    public int CompanyId { get; set; }
    
    [MaxLength(50)]
    public string Setting { get; set; }
    
    [MaxLength(50)]
    public string SettingValue { get; set; }
}