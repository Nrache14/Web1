using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AgeController : ControllerBase
    {
        [HttpGet("AgeInMinutes/{ageInYears}")]
        public IActionResult AgeInMinutes(int ageInYears)
        {
            // 1 year = 525600 minutes (365 days)
            int minutes = ageInYears * 525600;
            return Ok($"Age in minutes: {minutes}");
        }

        [HttpPost("CalculateAge")]
        public IActionResult CalculateAge([FromBody] BirthDate birthDate)
        {
            if (birthDate == null)
                return BadRequest("Data sent was null");

            try
            {
                var birth = new DateTime(birthDate.Year, birthDate.Month, birthDate.Day);
                var today = DateTime.Today;
                int age = today.Year - birth.Year;
                if (birth > today.AddYears(-age)) age--;

                return Ok($"Calculated age: {age}");
            }
            catch
            {
                return BadRequest("Invalid date provided.");
            }
        }
    }
}

public record BirthDate
{
    public int Month { get; set; }
    public int Day { get; set; }
    public int Year { get; set; }
}