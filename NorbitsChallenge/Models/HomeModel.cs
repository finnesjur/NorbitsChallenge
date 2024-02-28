using System.Collections.Generic;
using NorbitsChallenge.Models.Dto;

namespace NorbitsChallenge.Models
{
    public class HomeModel
    {
        public List<CarDto> CompanyCars { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public int? TireCount { get; set; }
    }
}
