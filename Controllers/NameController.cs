using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class NameController : ControllerBase
    {
            [HttpGet("Greet/{name}")]
        public IActionResult Name(string name)
        {
            return Ok($"Hello {name}");
        }

        [HttpPost("Reverse")]
        public IActionResult Reverse([FromBody] UserCred userCred)
        {
            if (userCred == null)
            {
                return BadRequest("Data sent was null");
            }

            ArgumentNullException.ThrowIfNullOrWhiteSpace(userCred.Firstname);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(userCred.Lastname);

            string reversedFirstname = new string(userCred.Firstname.Reverse().ToArray());
            string reversedLastname = new string(userCred.Lastname.Reverse().ToArray());
            string reversed = $"{reversedFirstname} {reversedLastname}";

            return Ok($"Hi {reversed}");
        }
    }
}

public record UserCred
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = "";
}
